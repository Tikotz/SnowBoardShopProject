using SnowBoardShopProject.DB.Models;
using System.Linq;
using System.Windows.Forms;

namespace SnowBoardShopProject.DB
{
    class ForgotPassHandlerUserName : ForggotPassHendler
    {
        public override bool StepOne(string userName)
        {
            using (var db = new SnowBoardShopContext())
            {
                var Clients = db.Clients.Select(c => c).ToList();
                foreach (var Cl in Clients)
                {
                    if (userName == Cl.UserName)
                    {
                        return true;
                    }
                    else if (userName == "")
                    {
                        MessageBox.Show("Enter a UserName");
                        return false;
                    }
                    
                    if(Next != null)
                    {
                        Next.StepTwo(userName);
                    }
                }
                return false;
            }
        }
        public override bool StepTwo(string username)
        {
            using (var db = new SnowBoardShopContext())
            {
                var Clients = db.Clients.Select(c => c).ToList();
                foreach (var Cl in Clients)
                {
                    if (username == Cl.UserName)
                    {
                        return true;
                    }
                    else if (username != Cl.UserName)
                    {
                        return false;
                    }
                    if (Next != null)
                    {
                        Next.End(username);
                    }
                }
                return false;
            }
        }
        public override bool End(string username)
        {
            return false;
        }
    }
}
