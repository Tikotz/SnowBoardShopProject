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

namespace SnowBoardShopProject.Models
{
    public partial class MyAccountUserControl : UserControl
    {
        public MyAccountUserControl()
        {
            InitializeComponent();
        }

        private void MyAccountUserControl_Load(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                if (User.IsAdmin(LoginForm.ThisDbClient))
                {
                    var qur = db.Clients.Select(o => o).ToList();
                    dataGridView1.DataSource = qur;
                    dataGridView1.EndEdit();
                }
                else
                {
                    List<object> list = new List<object>();
                    list.Add(LoginForm.thisUser.GetInfo());
                    dataGridView1.DataSource = list;

                }
                
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            DbChanges.Save();
            MessageBox.Show("saved successfully");
        }
    }
}
