using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    public partial class ForgotPasswordUserControl : UserControl
    {
        public ForgotPasswordUserControl()
        {
            InitializeComponent();
        }

        public bool IsHide { get; private set; }


        private void getPaaawordbutton1_Click(object sender, EventArgs e)
        {
            SendAccountDetailsThroughEmail();

            MessageBox.Show("Chack your email !");

            LoginForm loginForm = new LoginForm();
            this.Hide();
            this.Size = new System.Drawing.Size(528, 731);
            loginForm.Dock = DockStyle.Fill;
            loginForm.BringToFront();
            IsHide = true;
        }

        public void SendAccountDetailsThroughEmail()
        {
            using (var db = new SnowBoardShopContext())
            {
                var subject = "ForgotPassword";
                var password = LoginForm.ThisDbClient.GetPassword(UsernameTextBox2.Text);
                var body = $"your password is: {password}";
                string from = "o*******@*****.com";
                MailMessage mail = new MailMessage(from, gmailTextBox1.Text);
                using (SmtpClient smtpclient = new SmtpClient())
                {
                    smtpclient.Port = 587;
                    smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpclient.UseDefaultCredentials = false;
                    smtpclient.Host = "smtp.gmail.com";
                    smtpclient.UseDefaultCredentials = false;
                    mail.Subject = subject;
                    mail.Body = body;
                    smtpclient.EnableSsl = true;
                    smtpclient.Credentials = new System.Net.NetworkCredential()

                    {
                        UserName = "o********@*****.com",
                        Password = "************"
                    };
                    smtpclient.Send(mail);
                }
            }
        }
    }
}

