using SnowBoardShopProject.DB;
using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SnowBoardShopProject.Models
{
    public partial class ProfileOrderList : UserControl
    {
        public ProfileOrderList()
        {
            InitializeComponent();
        }

        

        private void ProfileOrderList_Load(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.Id == LoginForm.thisUser.GetID()).FirstOrDefault();

                if (User.IsAdmin(LoginForm.ThisDbClient))
                {
                    var qur = db.Orders.Select(o => o).ToList();
                    dataGridView1.DataSource = qur;
                }
                else
                {
                    var query = db.Orders.Where(c => c.CustomerId == client.Id).Select(c => c).ToList();
                    dataGridView1.DataSource = query;

                }
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            using(var db = new SnowBoardShopContext())
            {
                var date = dateTimePicker1.Value.Date;
                var client = db.Clients.Where(c => c.Id == LoginForm.thisUser.GetID()).FirstOrDefault();
                var clients = db.Clients.Select(c => c).ToList();

                var count = 0;
                
                List<Order> orders = new List<Order>();
                if(client.UserName == "Admin")
                {
                    var query2 = db.Orders.Select(o => o).ToList();
                    foreach (var item in query2)
                    {

                        if (item.OrderDate.Value.Date == date)
                        {
                            count++;
                            orders.Add(item);
                        }
                    }
                    dataGridView1.DataSource = orders;
                    if (count == 0)
                    {
                        MessageBox.Show("there is no orders in that date");
                    }
                }
                else
                {
                    var query = db.Orders.Where(c => c.CustomerId == client.Id).Select(c => c).ToList();

                    foreach (var item in query)
                    {

                        if (item.OrderDate.Value.Date == date)
                        {
                            count++;
                            orders.Add(item);
                        }
                    }
                    dataGridView1.DataSource = orders;
                    if (count == 0)
                    {
                        MessageBox.Show("there is no orders in that date");
                    }
                }
            }
        }

        private void GetALL_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.Id == LoginForm.thisUser.GetID()).FirstOrDefault();

                if (User.IsAdmin(LoginForm.ThisDbClient))
                {
                    var qur = db.Orders.Select(o => o).ToList();
                    dataGridView1.DataSource = qur;
                }
                else
                {
                    var query = db.Orders.Where(c => c.CustomerId == client.Id).Select(c => c).ToList();
                    dataGridView1.DataSource = query;

                }
            }
        }
    }
}
