using SnowBoardShopProject.DB;
using SnowBoardShopProject.DB.Models;
using System;
using System.Net.Mail;
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


            ForggotPassHendler Email = new ForgotPassHandlerEmail();




            userName.SetNext(Email);
            Email.SetNext(null);


            //here i use "Chain of responsibility" to chack what is missing in the inputs from the "Forgot PasswordUserControl" and Hendeling the situation.
            if (!userName.StepOne(UsernameTextBox2.Text))
            {
                MessageBox.Show("username does NOT exist");
                return;
            }
            else if (!Email.StepOne(gmailTextBox1.Text))
            {
                MessageBox.Show("Email does NOT exist");
                return;
            }
            else
            {

            SendAccountDetailsThroughEmail();

            MessageBox.Show("Email is sent. Chack your email ! ");

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
                string from = "o**********@******.com";
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
                        UserName = "o**********@******.com",
                        Password = "****************"
                    };
                    smtpclient.Send(mail);
                }
            }
        }
    }
}

