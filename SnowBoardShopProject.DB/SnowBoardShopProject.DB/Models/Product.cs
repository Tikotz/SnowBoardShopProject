using System;
using System.Collections.Generic;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public int? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
