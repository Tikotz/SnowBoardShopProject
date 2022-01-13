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
                dataGridView1.DataSource = db.Clients.Where(a => a.Id == LoginForm.ThisClient.Id).Select(a => a).ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
