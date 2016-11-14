using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcShopping.Models;

namespace MvcShopping.ViewModel
{
    public class ShoppingCartViewModel :SharedViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}