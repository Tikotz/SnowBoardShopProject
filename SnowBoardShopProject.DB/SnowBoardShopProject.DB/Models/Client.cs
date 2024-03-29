﻿
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class Client : User
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Budget { get; set; }
        public string IsLogin { get; set; }

        public Client(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public virtual ICollection<Order> Orders { get; set; }



        public static bool ValidateEmail(string mail)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.Match(mail, pattern).Success;
        }
        public static bool ValidateName(string fullName)
        {
            string IsValidName = @"\D{2,18} \D{2,18}";
            return Regex.Match(fullName, IsValidName).Success;
        }
        public static bool ValidatePhone(string phone)
        {
            string Pattern = @"^[0-9]{10}$";

            return Regex.Match(phone, Pattern).Success;
        }
        public static bool ValidateUserName(string username)
        {
            string pattern1 = "^[A-Za-z][A-Za-z0-9_]{7,29}$";
            string pattern = "^[a-zA-Z0-9]([.-](?![.-])|[a-zA-Z0-9]){3,18}[a-zA-Z0-9]$";
            return Regex.Match(username, pattern1).Success;
        }
        public static bool ValidatePassword(string password)
        {
            string pattern = "(?=.*?[a - z])(?=.*?[A - Z])(?=.*?[0 - 9])";
            return Regex.Match(password, pattern).Success;
        }

        public static Client CreateClientInstance(string FirstName, string LastName, int PhoneNumber, string Email, string UserName, string Password)
        {
            Client newClient = new Client();

            newClient.FirstName = FirstName;
            newClient.LastName = LastName;
            newClient.PhoneNumber = PhoneNumber;
            newClient.Email = Email;
            newClient.UserName = UserName;
            newClient.Password = Password;

            return newClient;
        }
    }
}
