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
                var client = db.Clients.Where(c => c.Id == LoginForm.ThisClient.Id).FirstOrDefault();

                dataGridView1.DataSource = db.OrderDetails.Select(od => od).ToList();
                dataGridView1.ReadOnly = true;

                
            }
        }

        private void Removebutton1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                
                if(OrderIdtextBox1.Text != null)
                {
                    var remove = db.OrderDetails.Where(r => r.OrderId == int.Parse(OrderIdtextBox1.Text)).FirstOrDefault();
                    db.OrderDetails.Remove(remove);
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
