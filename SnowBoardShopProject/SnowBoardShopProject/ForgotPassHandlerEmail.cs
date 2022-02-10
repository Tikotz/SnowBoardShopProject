using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    class ForgotPassHandlerEmail : ForggotPassHendler
    {
        public override bool HendleRequest(string request)
        {
            using (var db = new SnowBoardShopContext())
            {
                var Clients = db.Clients.Select(c => c).ToList();
                foreach (var Cl in Clients)
                {
                    if (request == Cl.Email)
                    {
                        if (Next != null)
                        {
                            Next.HendleRequest(request);
                        }
                        return true;
                    }
                    else if (request == "")
                    {
                        MessageBox.Show("Enter Your Email");
                        return false;
                    }
                    
                    if(Next != null)
                    {
                        Next.HendleRequest(request);
                        return false;
                    }
                }
                return false;

            }
        }
    }
}
