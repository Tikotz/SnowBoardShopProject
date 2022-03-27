using SnowBoardShopProject.DB.Models;
using System.Linq;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    class ForgotPassHandlerEmail : ForggotPassHendler
    {
        public override bool StepOne(string email)
        {
            using (var db = new SnowBoardShopContext())
            {
                var Clients = db.Clients.Select(c => c).ToList();
                foreach (var Cl in Clients)
                {
                    if (email == Cl.Email)
                    {
                        if (Next != null)
                        {
                            Next.StepTwo(email);
                        }
                        return true;
                    }
                    else if (email == "")
                    {
                        MessageBox.Show("Enter Your Email");
                        return false;
                    }
                    
                    if(Next != null)
                    {
                        Next.End(email);
                        return false;
                    }
                }
                return false;

            }
        }
        public override bool StepTwo(string email)
        {
            using (var db = new SnowBoardShopContext())
            {
                var Clients = db.Clients.Select(c => c).ToList();
                foreach (var Cl in Clients)
                {
                    if (email == Cl.Email)
                    {
                        if (Next != null)
                        {
                            Next.End(email);
                        }
                        return true;
                    }
                    else if (email != Cl.Email)
                    {
                        return false;
                    }
                    if (Next != null)
                    {
                        Next.End(email);
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
