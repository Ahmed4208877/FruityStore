using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruity.Models;
using fruity.BI;
using Domains;
using Microsoft.AspNetCore.Authorization;

namespace fruity.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        StoreWebsiteContext ctx;
        ICategoryService CategoryService;
        IItemservice ItemService;
        public ItemsController(StoreWebsiteContext Context, IItemservice Iservice, ICategoryService Cservice)
        {
            ctx = Context;
            ItemService = Iservice;
            CategoryService = Cservice;

        }
        public IActionResult Details(int id)
        {
            ItemDetailModel model = new ItemDetailModel();
            model.Item = ItemService.GetItem(id);
            model.RelatedItems = ItemService.GetAllRelated(id);
            model.UpSellItems = ItemService.GetUpSell();
            return View(model);
        }
        public IActionResult Shop()
        {
            
            return View();
        }
        public IActionResult AddToCart(int id)
        {
            //to open session and convet to json and 
            //ShopingCart oShopingCart = new ShopingCart();
            //string json = HttpContext.Session.GetString("Cart");
            //oShopingCart = JsonConvert.DeserializeObject<ShopingCart>(json);
            //HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(oShopingCart));

            //to convert whit extension methods
            ShopingCart oshopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            if (oshopingCart == null)
                oshopingCart = new ShopingCart();
            TbItem item = ItemService.GetItem(id);
            ShopingCartItem shopingItem = oshopingCart.listshopingCartItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                oshopingCart.listshopingCartItems.Add(new ShopingCartItem()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName = item.ImageName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice

                });
            }
            oshopingCart.Total = oshopingCart.listshopingCartItems.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", oshopingCart);
            return Redirect("/Home/Index");
        }

    }
}
