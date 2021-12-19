using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_ban_hang.Context;

namespace website_ban_hang.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set;}
        public List<Category> ListCategory { get; set;}
    }
}