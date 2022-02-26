using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBoardShopProject.DB
{
    public class User
    {
        private bool IsInitialized = false;
        private dynamic DbUser;
        public static Client ThisClient { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public User()
        {

        }
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public bool Initialize()
        {
            if (!IsInitialized)
            {
                using (var db = new SnowBoardShopContext())
                {
                    // Intialize user and apply found values to the main state of the class .
                    var DbUser = db.Clients.Where(c => c.UserName == UserName && c.Password == Password).Select(c => c).FirstOrDefault();

                    this.DbUser = DbUser;
                }
                IsInitialized = true;
                return IsInitialized;

            }
            else
            {
                return IsInitialized; // user already initialized.
            }
        }

        public static bool IsAdmin(Client client)
        {
            using (var db = new SnowBoardShopContext())
            {
                var admin = db.Admins.Where(a => a.AccountId == client.Id).FirstOrDefault();
                if (admin != null)
                {
                    return true;
                }
                return false;
            }

        }
        public string GetFullName()
        {
            return this.DbUser.FirstName + " " + this.DbUser.LastName;
        }
        public int GetID()
        {
            return this.DbUser.Id;
        }

        public int GetBudget()
        {
            return ThisClient.Budget;
        }

        public int setBudget(int newBudget)
        {
            ThisClient.Budget = newBudget;
            return ThisClient.Budget;
        }
        public int DecBudget(int price)
        {
            ThisClient.Budget -= price;
            return ThisClient.Budget;
        }
        public int IncBudget(int price)
        {
            ThisClient.Budget += price;
            return ThisClient.Budget;
        }

        public void Login()
        {
            using(var db = new SnowBoardShopContext())
            {
                var client = db.Clients.Where(c => c.Id == ThisClient.Id).Select(c => c).FirstOrDefault();
                client.IsLogin = "true";
                db.Update(client);
                db.SaveChanges();
            }
            
        }
        

        public Order GetOrders()
        {
            try
            {
                return this.DbUser.Orders.ToList();

            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool AddOrder(Order newOrder)
        {
            try
            {
                this.DbUser.Orders.Add(newOrder);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Save()
        {
            // Save the new document to SQL Express
            try
            {
                DbChanges.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #region Get Info
        public Client GetInfo()
        {
            try
            {
                
                return ThisClient;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Client GetInfo(int id)
        {
            using (var db = new SnowBoardShopContext())
            {
                ThisClient = db.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                return ThisClient;
            }
        }
        public static Client GetInfo(string username)
        {
            using (var db = new SnowBoardShopContext())
            {
                ThisClient = db.Clients.Where(c => c.UserName == username).Select(c => c).FirstOrDefault();
                return ThisClient;
            }
        }
        #endregion

        public string GetGmail()
        {
            return ThisClient.Email;
        }
        public string GetPassword(string username)
        {
            var client = GetInfo(username);
            return client.Password;
        }
    }
}
