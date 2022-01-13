using System;
using System.Collections.Generic;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class Client
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

        public virtual ICollection<Order> Orders { get; set; }
    }
}
