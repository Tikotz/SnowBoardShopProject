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

            MyLoad();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void UserNametextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordtextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PhoneNumbertextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void EmailtextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        #region MyMethods
        public void MyLoad()
        {
            using (var db = new SnowBoardShopContext())
            {
                if (User.IsAdmin(LoginForm.ThisDbClient))
                {
                    var qur = db.Clients.Select(o => o.Id).ToList();
                    clientIdComboBox1.DataSource = qur;
                    var id = (int)clientIdComboBox1.SelectedItem;
                    var client = db.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                    FirstNametextBox3.Text = client.FirstName;
                    LastNametextBox4.Text = client.LastName;
                    EmailtextBox6.Text = client.Email;
                    PhoneNumbertextBox5.Text = client.PhoneNumber.ToString();
                    UserNametextBox1.Text = client.UserName;
                    PasswordtextBox1.Text = client.Password;
                    BudgettextBox1.Text = client?.Budget.ToString();
                }
                else
                {

                    UserLoad();

                }
            }
        }

        public void Change()
        {
            using (var db = new SnowBoardShopContext())
            {
                var id = (int)clientIdComboBox1.SelectedItem;
                var client = db.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                FirstNametextBox3.Text = client.FirstName;
                LastNametextBox4.Text = client.LastName;
                EmailtextBox6.Text = client.Email;
                PhoneNumbertextBox5.Text = client.PhoneNumber.ToString();
                UserNametextBox1.Text = client.UserName;
                PasswordtextBox1.Text = client.Password;
                BudgettextBox1.Text = client?.Budget.ToString();
            }
        }


        public void UserLoad()
        {
            using (var db = new SnowBoardShopContext())
            {
                if (User.IsAdmin(LoginForm.ThisDbClient))
                {
                    var qur = db.Clients.Select(o => o.Id).ToList();
                    clientIdComboBox1.DataSource = qur;
                    var id = (int)clientIdComboBox1.SelectedItem;
                    var client = db.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                    FirstNametextBox3.Text = client.FirstName;
                    LastNametextBox4.Text = client.LastName;
                    EmailtextBox6.Text = client.Email;
                    PhoneNumbertextBox5.Text = client.PhoneNumber.ToString();
                    UserNametextBox1.Text = client.UserName;
                    PasswordtextBox1.Text = client.Password;
                    BudgettextBox1.Text = client?.Budget.ToString();
                }
                else
                {
                    var client = LoginForm.thisUser.GetInfo();
                    clientIdComboBox1.Visible = false;
                    Clientlabel1.Visible = false;

                    FirstNametextBox3.Text = client.FirstName;
                    LastNametextBox4.Text = client.LastName;
                    EmailtextBox6.Text = client.Email;
                    PhoneNumbertextBox5.Text = client.PhoneNumber.ToString();
                    UserNametextBox1.Text = client.UserName;
                    PasswordtextBox1.Text = client.Password;
                    BudgettextBox1.Text = client?.Budget.ToString();
                }
            }
        }

        #endregion

        private void clientIdComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void saveButton1_Click_1(object sender, EventArgs e)
        {
            if (User.IsAdmin(LoginForm.ThisDbClient))
            {
                var client = User.GetInfo((int)clientIdComboBox1.SelectedItem);
                client.FirstName = FirstNametextBox3.Text;
                client.LastName = LastNametextBox4.Text;
                client.Email = EmailtextBox6.Text;
                client.PhoneNumber = int.Parse(PhoneNumbertextBox5.Text);
                client.UserName = UserNametextBox1.Text;
                client.Password = PasswordtextBox1.Text;
                client.Budget = int.Parse(BudgettextBox1.Text);

                client.Save();
                this.Dispose();
            }
            else
            {
                var client = User.GetInfo(LoginForm.ThisDbClient.Id);
                client.FirstName = FirstNametextBox3.Text;
                client.LastName = LastNametextBox4.Text;
                client.Email = EmailtextBox6.Text;
                client.PhoneNumber = int.Parse(PhoneNumbertextBox5.Text);
                client.UserName = UserNametextBox1.Text;
                client.Password = PasswordtextBox1.Text;
                client.Budget = int.Parse(BudgettextBox1.Text);

                client.Save();
                MessageBox.Show("Saved");
                this.Dispose();
            }
        }
    }
}
