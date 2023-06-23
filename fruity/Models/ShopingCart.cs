using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruity.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            listshopingCartItems = new List<ShopingCartItem>(); 
        }
        public List<ShopingCartItem> listshopingCartItems { get; set; }

        public decimal Total { get; set; }


    }


}
