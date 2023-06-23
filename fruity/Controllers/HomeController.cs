
using fruity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruity.BI;
using Domains;
using Microsoft.Extensions.Logging;

namespace fruity.Controllers
{
    public class HomeController : Controller
    {
        StoreWebsiteContext ctx;
        IItemservice IService;
        ICategoryService CService;
        public HomeController(IItemservice Service,ICategoryService ICService, StoreWebsiteContext Context)
        {
            IService = Service;
            ctx = Context;
            CService = ICService;
        }

        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            ViewBag.Review = ctx.Reviews.ToList();
            ViewBag.ItemImage = ctx.TbItemImages.ToList();
            //ClsItem oclsItem = new ClsItem();
            //return View(oclsItem.GetAll());
            //ViewBag.Image = IService.GetImage();
            model.lisCategory = CService.GetAll();
            model.lisItem = IService.GetAll();
            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }

       


        [HttpPost]
        public IActionResult SaveReview(Review model)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact", model);
            }
            ctx.Reviews.Add(model);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
