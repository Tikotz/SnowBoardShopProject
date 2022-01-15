using SnowBoardShopProject.DB.Models;
using SnowBoardShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static Client ThisClient { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Loginbutton1_Click(object sender, EventArgs e)
        {
            using (var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.UserName == UsernametextBox2.Text && c.Password == PasswordtextBox1.Text)
                    .Select(c => c).FirstOrDefault();

                // new User(cart, budget)
                // User.decreaseBufget(int) 
                

                if (client != null)
                {
                    //client.IsLogin = "true";
                    ThisClient = client;
                    //ThisClient.IsLogin = "true";
                    Form1 form = new Form1();
                    form.ShowDialog();
                    db.SaveChanges();
                    this.Dispose();
                    
                }
                var clientDetails = db.Clients.Where(c => c.UserName == UsernametextBox2.Text && c.Password == PasswordtextBox1.Text)
                    .Select(c => c).ToList();

                

                if (client == null)
                {
                    ErrorLogin.Text = "Somthing went wrong try again :(";
                    ErrorLogin.Visible = true;
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientsUserControl clientUserControl = new ClientsUserControl();
            panel1.Controls.Add(clientUserControl);
            clientUserControl.Dock = DockStyle.Fill;
            clientUserControl.BringToFront();
            this.Size = new System.Drawing.Size(1200,703);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ClientsUserControl.lastWighth = this.Width;
            ClientsUserControl.lasthighth = this.Height;
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            
                this.Size = new System.Drawing.Size(528,731);
            
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var text = "Bye Bye have a nice day !";
            var caption = "Exit";
            var botton = MessageBoxButtons.OK;
            MessageBox.Show(text, caption, botton);
        }
    }
}
