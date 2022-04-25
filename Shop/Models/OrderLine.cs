using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class OrderLine
    {
        public int? Orderid { get; set; }
        public int? Productid { get; set; }
        public int? Quantity { get; set; }
    }
}
