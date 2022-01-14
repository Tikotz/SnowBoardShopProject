using System;
using System.Collections.Generic;

#nullable disable

namespace SnowBoardShopProject.DB.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Client Customer { get; set; }
    }
}
