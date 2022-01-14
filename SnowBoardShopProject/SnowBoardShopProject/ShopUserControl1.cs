using SnowBoardShopProject.DB.Models;
using SnowBoardShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    public partial class ShopUserControl : UserControl
    {
        public ShopUserControl()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                cmbBoards.DataSource = db.Products.OrderBy(p => p.ProductName).Select(a => a.ProductName).ToList();

                var client = db.Clients.Where(c => c.UserName == LoginForm.ThisClient.UserName && c.Password == LoginForm.ThisClient.Password).Select(c => c).FirstOrDefault();
                ClientNametextBox1.Text = client.FirstName + " " + client.LastName;

            }
        }

        private void cmbBoards_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {

            }
        }

        private void PricetextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbBoards_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                QuantitycomboBox1.Text = "1";
                var price = db.Products.Where(a => a.ProductName == cmbBoards.AccessibilityObject.Value).Select(a => a.UnitPrice).FirstOrDefault();
                if (QuantitycomboBox1.Text != "0")
                {
                    PricetextBox1.Text = Convert.ToString(price);
                }
                else
                {
                    PricetextBox1.Text = "0";
                }
            }
        }

        private void SaveOrderbutton1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {

                int price = int.Parse(PricetextBox1.Text);
                var budget = LoginForm.ThisClient.Budget;
                if ((budget >= price) && QuantitycomboBox1.Text != "0")
                {
                    var client = db.Clients.Where(c => c.UserName == LoginForm.ThisClient.UserName && c.Password == LoginForm.ThisClient.Password).Select(c => c).FirstOrDefault();
                    var thisBoard = cmbBoards.SelectedValue;
                    var remove = db.Products.Where(b => b.ProductName == thisBoard).Select(b => b).FirstOrDefault();
                    if (remove.UnitInStock == 0)
                    {
                        MessageBox.Show("cant purchase this board because it out of Stock... Sorry");
                    }
                    else
                    {
                        remove.UnitInStock -= 1;

                        Order newOrder = new Order();
                        newOrder.CustomerId = LoginForm.ThisClient.Id;
                        newOrder.OrderDate = DateTime.Now;
                        //newOrder.Customer = LoginForm.ThisClient;
                        //client.Orders.Add(newOrder);
                        db.Orders.Add(newOrder);
                        db.SaveChanges();

                        using (var db2 = new SnowBoardShopContext())
                        {
                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.OrderId = newOrder.OrderId;
                            orderDetail.ProductId = remove.ProductId;
                            orderDetail.UnitPrice = price;
                            orderDetail.Quantity = short.Parse(QuantitycomboBox1.Text);
                            db2.OrderDetails.Add(orderDetail);

                            //add to orders
                            //add to order details
                            LoginForm.ThisClient.Budget -= price;
                            
                            MessageBox.Show("purchase succssesfully");
                            db2.SaveChanges();
                        }
                        using (var db3 = new SnowBoardShopContext())
                        {
                            client.Orders.Add(newOrder);
                            db3.SaveChanges();
                        }
                    }
                }
                else
                {
                    if (budget < price)
                    {
                        var text = "you dont have enough money please chack your Budget";
                        var caption = "Purchased FAILD";
                        var botton = MessageBoxButtons.OK;
                        var icon = MessageBoxIcon.Error;
                        MessageBox.Show(text, caption, botton, icon);
                    }
                    else
                    {
                        var text = "Somthing is missing chack your order again";
                        var caption = "Purchased FAILD";
                        var botton = MessageBoxButtons.OK;
                        var icon = MessageBoxIcon.Error;
                        MessageBox.Show(text, caption, botton, icon);
                    }
                }
            }
        }

        private void QuantitycomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                var price = db.Products.Where(a => a.ProductName == cmbBoards.AccessibilityObject.Value).Select(a => a.UnitPrice).FirstOrDefault();


                switch ((string)QuantitycomboBox1.SelectedItem)
                {
                    case "1":
                        PricetextBox1.Text = Convert.ToString(price);
                        break;
                    case "2":
                        PricetextBox1.Text = Convert.ToString(price * 2);
                        break;
                }
            }
        }
    }
}
