using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruity.Models;
using Microsoft.EntityFrameworkCore;
using Domains;
using Microsoft.Extensions.Logging;

namespace fruity.BI
{
    public interface IItemservice
    {
        List<TbItem> GetAll();
        List<VwItemCategory> GetAllApi();

        List<TbItem> GetAllRelated(int id);
        List<TbItem> GetUpSell();

        TbItem GetItem(int Id);
        string GetIImage(int Id);
        List<ClsVwItemImage> GetImage();
        void Delete(int Id);
        bool EditItem(TbItem item);
        void SaveNewItem(TbItem item);

        


    }




    public class ClsItem :IItemservice
    {
        StoreWebsiteContext ctx;
        public ClsItem(StoreWebsiteContext context )
        {
            ctx = context;
            
        }

        public List<TbItem> GetAll()

        {
            try
            {
                List<TbItem> lstitems = new List<TbItem>();
                lstitems = ctx.TbItems.Include(a => a.TbItemImages).OrderByDescending(a => a.CreationDate).ToList();
                return lstitems;

            }
            catch (Exception ex)
            {

                throw new BlException(ex);
            }
            
        }
        public List<VwItemCategory> GetAllApi()

        {
            List<VwItemCategory> lstitems = new List<VwItemCategory>();
            lstitems = ctx.VwItemCategories.ToList();
            return lstitems;
        }

        public List<TbItem> GetAllRelated(int id)
        {
            List<TbItem> lstitems = new List<TbItem>();
            decimal range = ctx.TbItems.FirstOrDefault(a=>a.ItemId==id).SalesPrice;
            lstitems = ctx.TbItems.Where(a => a.SalesPrice == (range+10) ||  a.SalesPrice == (range-10) || a.SalesPrice ==range).ToList();
            return lstitems;
        }

       public List<TbItem> GetUpSell()
        {
            var quary = from i in ctx.TbItems
                        join dis in ctx.TbItemDiscounts
                        on i.ItemId equals dis.ItemId
                        where dis.EndDate >=DateTime.Now
                        select i;
            return quary.ToList();
                       
        }




        public TbItem GetItem(int Id)
        {
            TbItem otbItem = new TbItem();
            
            otbItem = ctx.TbItems.Include(a=>a.Category).FirstOrDefault(a => a.ItemId == Id);
            return otbItem;
        }
        public string GetIImage(int Id)
        {
            //TbItemImage oTbItemImage = new TbItemImage();
            string ImageName = ctx.TbItemImages.Where(a => a.ItemId == Id).Select(a => a.ImageName).ToString();
            //oTbItemImage = oStoreWebsiteContext.TbItemImages.FirstOrDefault(a => a.ItemId == Id);
            return ImageName;
        }

        public List<ClsVwItemImage> GetImage()
        {
            var query = from i in ctx.TbItems
                        join ii in ctx.TbItemImages
                        on i.ItemId equals ii.ItemId
                        select new ClsVwItemImage
                        {
                            ItemId = i.ItemId,
                            ItemName = i.ItemName,
                            SalesPrice = i.SalesPrice,
                            ImageName = ii.ImageName,
                            Quantity = i.Quantity

                        };

            return query.ToList();

        }



        public void SaveNewItem(TbItem item)
        {

            ctx.TbItems.Add(item);
            ctx.SaveChanges();
        }

        public bool EditItem(TbItem item )
        {
            try
            {
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
            
        }

        public void Delete(int Id)
        {
            
            TbItem item = ctx.TbItems.FirstOrDefault(a => a.ItemId == Id);
            ctx.Remove(item);
            ctx.SaveChanges();
        }



    }
}
