using SnowBoardShopProject.DB.Models;
using System;
using System.Windows.Forms;


namespace SnowBoardShopProject
{
    public partial class ClientsUserControl : UserControl
    {

        public static int lastWighth { get; set; }
        public static int lasthighth { get; set; }

        public static bool IsHide { get; set; }

        public event Action<Client> clientadded;
        public ClientsUserControl()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            ClientsUserControl clientsUserControl = new ClientsUserControl();
            clientsUserControl.clientadded += (newclient) =>
            {

                clientsUserControl.lblMessegeTxt.Text = "the client " + newclient.FirstName + " " + newclient.LastName + " added succesfully";
            };
            clientsUserControl.Parent = panel1;
        }

        

        private void AddClient_Click_1(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                //Modole: Client. -עשיתי פה ולידציה על מספר פלאפון תקין,מס זהות תקין,שם ושם משפחה תקינים. ראה ולידציות ב
                //here im using "Factory method" to Create a new client.
                if (Client.ValidateEmail(EmailtextBox6.Text) && Client.ValidateName(FirstNametextBox3.Text + " " + LastNametextBox4.Text) && Client.ValidatePhone(PhoneNumbertextBox5.Text) && Client.ValidatePassword(PasswordtextBox1.Text) && Client.ValidateUserName(UserNametextBox1.Text))
                {
                    var newClient = Client.CreateClientInstance(FirstNametextBox3.Text, LastNametextBox4.Text, Convert.ToInt32(PhoneNumbertextBox5.Text), EmailtextBox6.Text, UserNametextBox1.Text, PasswordtextBox1.Text);
                   
                    db.Clients.Add(newClient);
                    
                    db.SaveChanges();
                    MessageBox.Show("Client Added Succesfully");
                    LoginForm loginForm = new LoginForm();
                    this.Hide();
                    loginForm.Dock = DockStyle.Fill;
                    loginForm.BringToFront();
                    this.Size = new System.Drawing.Size(528, 731);
                    IsHide = true;
                }
                else
                {
                    if (!Client.ValidateEmail(EmailtextBox6.Text))
                    {
                        lblMessegeTxt.Text = "Email is not valid";
                        return;
                    }
                    if (!Client.ValidateName(FirstNametextBox3.Text + " " + LastNametextBox4.Text))
                    {
                        lblMessegeTxt.Text = "Youre first name OR last name is not valid";
                        return;
                    }
                    if(!Client.ValidatePhone(PhoneNumbertextBox5.Text))
                    {
                        lblMessegeTxt.Text = "Youre phone number is not valid";
                        return;
                    }
                    if (!Client.ValidateUserName(UserNametextBox1.Text))
                    {
                        lblMessegeTxt.Text = "Youre username is not valid";
                        return;
                    }
                    if (!Client.ValidatePassword(PasswordtextBox1.Text))
                    {
                        lblMessegeTxt.Text = "Youre password is not valid";
                        return;
                    }
                    lblMessegeTxt.Text = "one or more of the following information is not valid";

                    
                }
                
            }
        }
    }
}
