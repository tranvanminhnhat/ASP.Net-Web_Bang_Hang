using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_ban_hang.Context;

namespace website_ban_hang.Models
{
    public class CartModel
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}