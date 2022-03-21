using Microsoft.EntityFrameworkCore;
using SnowBoardShopProject.DB;
using SnowBoardShopProject.DB.Models;
using SnowBoardShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

                ClientNametextBox1.Text = LoginForm.thisUser.GetFullName();

            }
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

            GetBoardPics(cmbBoards.AccessibilityObject.Value);

        }

        private void SaveOrderbutton1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {

                int price = int.Parse(PricetextBox1.Text);
                var budget = LoginForm.ThisDbClient.GetBudget();
                if ((budget >= price) && QuantitycomboBox1.Text != "0")
                {

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
                        newOrder.CustomerId = LoginForm.ThisDbClient.Id;
                        newOrder.OrderDate = DateTime.Now;
                        db.Orders.Add(newOrder);
                        db.SaveChanges();




                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderId = newOrder.OrderId;
                        orderDetail.ProductId = remove.ProductId;
                        orderDetail.UnitPrice = price;
                        orderDetail.Quantity = short.Parse(QuantitycomboBox1.Text);
                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();

                        MessageBox.Show("purchase succssesfully");
                        var client = db.Clients.Where(c => c.Id == LoginForm.ThisDbClient.Id).Select(c => c).FirstOrDefault();
                        client.Budget -= price;
                        db.Update(client);
                        db.SaveChanges();

                        var client2 = db.Clients.Where(c => c.Id == LoginForm.ThisDbClient.Id).Select(c => c).FirstOrDefault();
                        client2.Orders.Add(newOrder);
                        db.SaveChanges();


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
            //using(var db = new SnowBoardShopContext())
            //{
            //    OrderDetail orderDetail = new OrderDetail();
            //    db.OrderDetails.Add(orderDetail);
            //    db.SaveChanges();

            //}
        }

        public void GetBoardPics(string BoardName)
        {
            switch (BoardName)
            {
                case "Prosses":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.Procces;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.FlyingV;
                    break;
                case "Custome":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.custom;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.FlyingV;
                    break;
                case "FlightAttendent":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.flight_attendant;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.DirectionalCamber;
                    break;
                case "SkeletonKey":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.SkeletonKey;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.DirectionalCamber;
                    break;
                case "HomeTownHero":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.HomeTownHero;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.DirectionalCamber;
                    break;
                case "DeepThinker":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.DeepThinker;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.DirectionalCamber;
                    break;
                case "Kilroy3D":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.Kilroy3D;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.camber;
                    break;
                case "T.RisePro":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.T_RisePro;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "ColdBrew":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.ColdBrew;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "T.RiseOrca":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.T_RiseOrca;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "SkateBanana":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.SkateBanana;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_original_banana_contour_3;
                    break;
                case "GoldenOrca":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.GoldenOrca;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "MagicBM":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.MagicBM;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "LostRocket":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.LostRocket;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.C3;
                    break;
                case "GWO":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.GWO;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_original_banana_contour_3;
                    break;
                case "HeadSpace":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.HeadSpace;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.C3;
                    break;
                case "Finest":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.Finest;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "RidersChoise":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.RidersChoise;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.lib_tech_c2_contour;
                    break;
                case "DanceHaul":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.DanceHaul;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.DirectionalCamber;
                    break;
                case "Assessin":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.Assessin;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.camber;
                    break;
                case "AssessinPro":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.AssessinPro;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.camber;
                    break;
                case "Super8":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.Super8;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.DirectionalCamber;
                    break;
                case "SnowTrooper":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.SnowTrooper;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.Never_Summer_original_rocker_camber_profile;
                    break;
                case "ProtoSynthesis":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.ProtoSynthesis;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.shockWave;
                    break;
                case "ProtoUltra":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.ProtoUltra;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.shockWave;
                    break;
                case "ProtoSlinger":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.ProtoSlinger;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.shockWave;
                    break;
                case "ProtoFR":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.ProtoFR;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.trippleRokerCamber;
                    break;
                case "ShaperTwin":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.ShaperTwin;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.Never_Summer_Fusion_Rocker_Camber;
                    break;
                case "Harpoon":
                    pictureBox1.Image = SnowBoardShopProject.Properties.Resources.Harpoon;
                    pictureBox2.Image = SnowBoardShopProject.Properties.Resources.Never_Summer_Fusion_Rocker_Camber;
                    break;


                default:
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    break;
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
