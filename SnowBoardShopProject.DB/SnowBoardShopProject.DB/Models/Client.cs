
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



        public bool ValidateEmail(string mail)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.Match(mail, pattern).Success;
        }
        public bool ValidateName(string fullName)
        {
            string IsValidName = @"\D{2,18} \D{2,18}";
            return Regex.Match(fullName, IsValidName).Success;
        }
        public bool ValidatePhone(string phone)
        {
            string Pattern = @"\+(9[976]\d | 8[987530]\d | 6[987]\d | 5[90]\d | 42\d | 3[875]\d | 2[98654321]\d | 9[8543210] | 8[6421] | 6[6543210] | 5[87654321] | 4[987654310] | 3[9643210] | 2[70] | 7 | 1)\d{ 1,14}$";
            return Regex.Match(phone, Pattern).Success;
        }
        public bool ValidateUserName(string username)
        {
            string pattern = @"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$";
            return Regex.Match(pattern, username).Success;
        }
        public bool ValidatePassword(string password)
        {
            string pattern = @"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$";
            return Regex.Match(pattern, password).Success;
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
