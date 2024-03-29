﻿using SnowBoardShopProject.DB;
using SnowBoardShopProject.Models;
using System;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DbChanges.ChangeIsLogin(User.ThisClient.GetInfo());

            var text = $"Bye Bye {User.ThisClient.FirstName} {User.ThisClient.LastName}\n keep Ride in style !";
            var caption = "Exit";
            var botton = MessageBoxButtons.OK;
            MessageBox.Show(text, caption, botton);

        }

        
        private void enterShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopUserControl shopUserControl = new ShopUserControl();
            panel1.Controls.Add(shopUserControl);
            this.WindowState = FormWindowState.Maximized;
            shopUserControl.Dock = DockStyle.Fill;
            shopUserControl.BringToFront();
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
