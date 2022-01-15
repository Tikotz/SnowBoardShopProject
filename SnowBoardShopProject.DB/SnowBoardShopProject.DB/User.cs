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
        private string UserName { get; set; }
        private string Password { get; set; }

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
                    var DbUser = db.Clients.Where(c => c.UserName == this.UserName && c.Password == this.Password).FirstOrDefault();
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
            return this.DbUser.Budget;
        }

        public int setBudget(int newBudget)
        {
            this.DbUser.Budget = newBudget;
            return this.DbUser.Budget;
        }
        public int DecBudget(int price)
        {
            this.DbUser.Budget -= price;
            return this.DbUser.Budget;
        }
        public int IncBudget(int price)
        {
            this.DbUser.Budget += price;
            return this.DbUser.budget;
        }

        public void Login()
        {
            this.DbUser.IsLogin = "true";
        }
        public void Logout()
        {
            this.DbUser.IsLogin = "false";
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

        public Client GetInfo()
        {
            try
            {
                Client client = new Client();
                client = this.DbUser;
                
                return client;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save()
        {
            // Save the new document to SQL Express
            try
            {
                this.DbUser.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
