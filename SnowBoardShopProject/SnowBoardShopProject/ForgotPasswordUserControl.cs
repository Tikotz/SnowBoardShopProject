using SnowBoardShopProject.DB;
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
            ForggotPassHendler userName = new ForgotPassHandlerUserName();
            ForggotPassHendler userName2 = new ForgotPassHandlerUserName2();


            ForggotPassHendler Email = new ForgotPassHandlerEmail();
            ForggotPassHendler Email2 = new ForgotPassHandlerEmail2();


            ForggotPassHendler End = new ForgotPassHandlerEnd();


            userName.SetNext(userName2);
            userName2.SetNext(End);
            Email.SetNext(Email2);
            Email2.SetNext(End);
            End.SetNext(null);


            //here i use "Chain of responsibility" to chack what is missing in the inputs from the "Forgot PasswordUserControl" and Hendeling the situation.
            if (!userName.HendleRequest(UsernameTextBox2.Text))
            {
                return;
            }
            else if (!Email.HendleRequest(gmailTextBox1.Text))
            {
                return ;
            }
            else
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

