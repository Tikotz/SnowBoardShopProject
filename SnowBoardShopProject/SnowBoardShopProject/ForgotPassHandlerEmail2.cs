using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    class ForgotPassHandlerEmail2 : ForggotPassHendler
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
                    else if (request != Cl.Email)
                    {
                        MessageBox.Show("Your Email is NOT Correct");
                        return false;
                    }
                    if (Next != null)
                    {
                        Next.HendleRequest(request);
                    }
                }
                return false;
            }
        }
    }
}
