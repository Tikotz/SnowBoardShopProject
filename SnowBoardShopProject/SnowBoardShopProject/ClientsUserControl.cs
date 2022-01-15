using SnowBoardShopProject.DB.Models;
using SnowBoardShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SnowBoardShopProject
{
    public partial class ClientsUserControl : UserControl
    {
        Client newClient = new Client();

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PhoneNumbertextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EmailtextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LastNametextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FirstNametextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void IdtextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMessegeTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddClient_Click_1(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {

                if (Client.IsEmailValid(EmailtextBox6.Text) && Client.IsFNameValid(FirstNametextBox3.Text + " " + LastNametextBox4.Text) && Client.IsDecimal(PhoneNumbertextBox5.Text))
                {

                    newClient.FirstName = FirstNametextBox3.Text;
                    newClient.LastName = LastNametextBox4.Text;
                    newClient.PhoneNumber = Convert.ToInt32(PhoneNumbertextBox5.Text);
                    newClient.Email = EmailtextBox6.Text;
                    newClient.UserName = UserNametextBox1.Text;
                    newClient.Password = PasswordtextBox1.Text;

                    db.Clients.Add(newClient);

                    MessageBox.Show("Client Added Succesfully");
                }
                else
                {
                    if (!Client.IsEmailValid(EmailtextBox6.Text))
                    {
                        lblMessegeTxt.Text = "Email is not valid";
                        return;
                    }
                    if (!Client.IsFNameValid(FirstNametextBox3.Text + " " + LastNametextBox4.Text))
                    {
                        lblMessegeTxt.Text = "Youre first name OR last name is not valid";
                        return;
                    }
                    lblMessegeTxt.Text = "one or more of the following information is not valid";

                    db.SaveChanges();
                    this.Hide();
                    IsHide = true;
                }
            }
        }
    }
}
