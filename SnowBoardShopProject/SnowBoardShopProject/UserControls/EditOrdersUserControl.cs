using SnowBoardShopProject.DB;
using SnowBoardShopProject.DB.Models;
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
    public partial class EditOrdersUserControl : UserControl
    {
        public EditOrdersUserControl()
        {
            InitializeComponent();
        }

        private void EditOrdersUserControl_Load(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.Id == LoginForm.thisUser.GetID()).FirstOrDefault();

                var orders = db.Orders.Where(c => c.CustomerId == client.Id).Select(c => c).ToList();
                

                try
                {

                    if (User.IsAdmin(LoginForm.ThisDbClient))
                    {
                        var qur = db.OrderDetails.ToList();
                        dataGridView1.DataSource = qur;
                    }
                    else
                    {
                        var od1 = new List<OrderDetail>();
                        foreach (var item in orders)
                        {
                            od1.Add(db.OrderDetails.Where(o => o.OrderId == item.OrderId).Select(o => o).FirstOrDefault());
                        }
                        dataGridView1.DataSource = od1;
                        dataGridView1.ReadOnly = true;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("You still didnt order anything... Go make an order first");

                }
            }
        }

        private void Removebutton1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                if (OrderIdtextBox1.Text != null)
                {
                    var remove = db.OrderDetails.Where(r => r.OrderId == int.Parse(OrderIdtextBox1.Text)).FirstOrDefault();
                    var remove2 = db.Orders.Where(r => r.OrderId == int.Parse(OrderIdtextBox1.Text)).FirstOrDefault();

                    db.OrderDetails.Remove(remove);
                    db.Orders.Remove(remove2);
                    var product = db.Products.Where(p => p.ProductId == remove.ProductId).Select(p => p).FirstOrDefault();
                    product.UnitInStock += 1;
                    LoginForm.thisUser.IncBudget((int)product.UnitPrice);
                }
                db.SaveChanges();

                dataGridView1.DataSource = db.OrderDetails.Select(od => od).ToList();
            }
        }

        private void Editbutton1_Click(object sender, EventArgs e)
        {
            OrderIdlabel1.Visible = true;
            OrderIdtextBox1.Visible = true;
        }
    }
}
