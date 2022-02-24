using SnowBoardShopProject.DB;
using SnowBoardShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Add_Clients_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenShop_Click(object sender, EventArgs e)
        {
            
        }

        private void GetProfilebutton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DbChanges.ChangeIsLogin(User.ThisClient.GetInfo());

            var text = $"Bye Bye {User.ThisClient.FirstName} {User.ThisClient.LastName}\n keep Ride in style !";
            var caption = "Exit";
            var botton = MessageBoxButtons.OK;
            MessageBox.Show(text, caption, botton);

        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void enterShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopUserControl shopUserControl = new ShopUserControl();
            panel1.Controls.Add(shopUserControl);
            this.WindowState = FormWindowState.Maximized;
            shopUserControl.Dock = DockStyle.Fill;
            shopUserControl.BringToFront();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void orderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1200, 703);
            ProfileOrderList profileUserControl = new ProfileOrderList();
            panel1.Controls.Add(profileUserControl);
            profileUserControl.Dock = DockStyle.Fill;
            profileUserControl.BringToFront();
        }

        private void myAccountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1200, 703);
            MyAccountUserControl myAccountUserControl = new MyAccountUserControl();
            panel1.Controls.Add(myAccountUserControl);
            myAccountUserControl.Dock = DockStyle.Fill;
            myAccountUserControl.BringToFront();
        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1200, 703);
            EditOrdersUserControl editOrdersUserControl = new EditOrdersUserControl();
            panel1.Controls.Add(editOrdersUserControl);
            editOrdersUserControl.Dock = DockStyle.Fill;
            editOrdersUserControl.BringToFront();
        }
    }
}
