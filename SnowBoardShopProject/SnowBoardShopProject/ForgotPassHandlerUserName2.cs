using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBoardShopProject
{
    class ForgotPassHandlerUserName2 : ForggotPassHendler
    {
        public override bool HendleRequest(string username)
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
                        MessageBox.Show("Username does not exist.");
                        
                        return false;
                    }
                    if (Next != null)
                    {
                        Next.HendleRequest(username);
                    }
                }
                return false;
            }
        }
    }
}
