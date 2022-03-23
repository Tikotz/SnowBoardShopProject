using SnowBoardShopProject.DB.Models;
using System.Linq;

namespace SnowBoardShopProject.DB
{
    public class DbChanges
    {
        public static void ChangeIsLogin(Client Subclient)
        {
            using (var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.UserName == Subclient.UserName && c.Password == Subclient.Password).Select(c => c).FirstOrDefault();
                if (client != null)
                {
                    if(client.IsLogin == "true")
                    {
                        client.IsLogin = "false";
                    }
                    else if(client.IsLogin == "false")
                    {
                        client.IsLogin = "false";
                    }
                    else
                    {
                        client.IsLogin = "true";
                    }
                    db.SaveChanges();
                }
            }
        }
        public static void Save()
        {
            using (var db = new SnowBoardShopContext())
            {
                db.SaveChanges();
            }
        }
    }
}
