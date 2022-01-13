using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class Clients
    {
        public Clients()
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

        public virtual ICollection<Order> Orders { get; set; }

        public static bool IsEmailValid(string mail)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.Match(mail, pattern).Success;
        }
        public static bool IsFNameValid(string fullame)
        {
            string IsValidName = @"\D{2,18} \D{2,18}";
            return Regex.Match(fullame, IsValidName).Success;
        }
        public static bool IsDecimal(string num)
        {
            string pattern = @"^\d+$";
            return Regex.IsMatch(num, pattern);

        }
    }
}
