﻿using SnowBoardShopProject.DB;
using SnowBoardShopProject.DB.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    public partial class LoginForm : Form
    {
        public static User thisUser { get; set; }
        public static User theAdmin { get; set; }

        public static Client ThisDbClient { get; set; } =new Client();

        public LoginForm()
        {
            InitializeComponent();
        }


        

        private void Loginbutton1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {

                thisUser = new User(UsernametextBox2.Text, PasswordtextBox1.Text);
                if (!thisUser.Initialize())
                {
                    ErrorLogin.Text = "User does not exist";
                    ErrorLogin.Visible = true;
                }
                else
                {

                    //DbChanges.ChangeIsLogin(User.ThisClient.GetInfo());


                    MainMenu form = new MainMenu();
                    using (var db2 = new SnowBoardShopContext())
                    {
                        // Intialize user and apply found values to the main state of the class .
                        var DbUser = db2.Clients.Where(c => c.UserName == UsernametextBox2.Text && c.Password == PasswordtextBox1.Text).Select(c => c).FirstOrDefault();
                        if (DbUser != null)
                        {
                            ThisDbClient = DbUser;
                            User.ThisClient = ThisDbClient;
                            ThisDbClient.Login();
                            form.ShowDialog();
                            this.Dispose();
                        }
                        else
                        {
                            ErrorLogin.Text = "UserName or Password is NOT correct";
                            ErrorLogin.Visible = true;
                        }
                    }
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientsUserControl clientUserControl = new ClientsUserControl();
            panel1.Controls.Add(clientUserControl);
            clientUserControl.Dock = DockStyle.Fill;
            clientUserControl.BringToFront();
            this.Size = new System.Drawing.Size(1200, 703);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ClientsUserControl.lastWighth = this.Width;
            ClientsUserControl.lasthighth = this.Height;
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(528, 731);

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            var text = "Bye Bye have a nice day !";
            var caption = "Exit";
            var botton = MessageBoxButtons.OK;
            MessageBox.Show(text, caption, botton);
        }

        private void forgotPasswordbutton2_Click(object sender, EventArgs e)
        {
            ForgotPasswordUserControl forgotPasswordUserControl = new ForgotPasswordUserControl();
            panel1.Controls.Add(forgotPasswordUserControl);
            forgotPasswordUserControl.Dock = DockStyle.Fill;
            forgotPasswordUserControl.BringToFront();
        }
    }
}
