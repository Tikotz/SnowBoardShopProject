using SnowBoardShopProject.DB;
using SnowBoardShopProject.DB.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SnowBoardShopProject.Models
{
    public partial class MyAccountUserControl : UserControl
    {
        public MyAccountUserControl()
        {
            InitializeComponent();
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
            try
            {
                if(FirstNametextBox3.Text == "" || LastNametextBox4.Text == "" || EmailtextBox6.Text == "" || PhoneNumbertextBox5.Text == "" || UserNametextBox1.Text == "" || PasswordtextBox1.Text == "" || BudgettextBox1.Text == "")
                {
                    throw new Exception();
                }
                else
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
            catch (Exception)
            {

                MessageBox.Show("there are some inputs with empty value. please try again ");
            }
            
        }

        private void MyAccountUserControl_Load(object sender, EventArgs e)
        {
            UserLoad();
        }
    }
}
