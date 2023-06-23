using Domains;
using fruity.BI;
using fruity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruity.Controllers
{
    public class OrderController : Controller
    {
        IItemservice IService;
        public OrderController(IItemservice Service)
        {
            IService = Service;
        }
        
        public IActionResult Cart()
        {
             ShopingCart oshopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            return View(oshopingCart);
        }
        public IActionResult RemoveItem(int id)
        {
            ShopingCart oshopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            oshopingCart.listshopingCartItems.Remove(oshopingCart.listshopingCartItems.Where(a => a.ItemId == id).FirstOrDefault());
            oshopingCart.Total = oshopingCart.listshopingCartItems.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", oshopingCart);
            return RedirectToAction("Cart");
        }
    }
}
