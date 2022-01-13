using System;
using System.Collections.Generic;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class Company
    {
        public Company()
        {
            Products = new HashSet<Product>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
