using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject.Models
{
    public partial class ProfileOrderList : UserControl
    {
        public ProfileOrderList()
        {
            InitializeComponent();
        }

        private void Loginbutton1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
            
        }

        private void SaveBudget_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProfileOrderList_Load(object sender, EventArgs e)
        {
            using(var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.Id == LoginForm.ThisClient.Id).FirstOrDefault();

                var query = db.Orders.Where(c => c.CustomerId == client.Id).Select(c => c).ToList();
                dataGridView1.DataSource = query;
                

                


                //var query = db.Orders.Join(db.Clients, order => order.CustomerId, client => client.Id, order => order.CustomerName);
            }
        }
    }
}
