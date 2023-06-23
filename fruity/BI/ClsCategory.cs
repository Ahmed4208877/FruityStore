using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruity.Models;
using Domains;
namespace fruity.BI
{
    public interface ICategoryService
    {
        List<TbCategory> GetAll();
    }



    public class ClsCategory :ICategoryService
    {
        StoreWebsiteContext ctx;
        public ClsCategory(StoreWebsiteContext context)
        {
            ctx = context;
        }
        public List<TbCategory> GetAll()
        {
            List <TbCategory> categories = ctx.TbCategories.ToList();
            return categories;

        }

        

    }
}
