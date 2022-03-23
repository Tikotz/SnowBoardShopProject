using SnowBoardShopProject.DB.Models;
using System.Linq;
using System.Windows.Forms;

namespace SnowBoardShopProject.DB
{
    class ForgotPassHandlerUserName : ForggotPassHendler
    {
        public override bool HendleRequest(string request)
        {
            using (var db = new SnowBoardShopContext())
            {
                var Clients = db.Clients.Select(c => c).ToList();
                foreach (var Cl in Clients)
                {
                    if (request == Cl.UserName)
                    {
                        return true;
                    }
                    else if (request == "")
                    {
                        MessageBox.Show("Enter a UserName");
                        return false;
                    }
                    
                    if(Next != null)
                    {
                        Next.HendleRequest(request);
                    }
                }
                return false;
            }
        }
    }
}
