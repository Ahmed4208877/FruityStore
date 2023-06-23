using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruity.BI;
using fruity.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Domains;
using Microsoft.AspNetCore.Authorization;

namespace fruity.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ItemController : Controller
    {
        IItemservice IService;
        ICategoryService CService;
        public ItemController(IItemservice Service,ICategoryService CaService)
        {
            IService = Service;
            CService = CaService;
        }

        public IActionResult List()
        {
           
            return View(IService.GetAll());
        }

        public IActionResult Edit(int? Id)
        {
            ViewBag.Category = CService.GetAll();

            if (Id == null)
            {

                return View();
            }
            else
            {

               

                return View(IService.GetItem((Int32)Id));
            }


        }

        public IActionResult Delete(int id)
        {

            IService.Delete(id);
            return RedirectToAction("List");
        }



        [HttpPost]
        public async Task <IActionResult> Save(TbItem model,List<IFormFile> Files)
        {


            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length >0)
                    {
                        string ImageName = Guid.NewGuid().ToString() +".jpg";
                        var filepaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", ImageName);
                        using (var stream = System.IO.File.Create(filepaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        model.ImageName = ImageName;
                    }
                }
                if (model.ItemId != 0)
                    IService.EditItem(model);
                else
                    IService.SaveNewItem(model);

                return RedirectToAction("List");
            }
            return View("Edit", model);



        }
    }
}
