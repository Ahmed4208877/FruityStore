using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
namespace fruity.Models
{
    public class ItemDetailModel
    {
        public TbItem Item { get; set; }
        public List<TbItem> RelatedItems { get; set; }
        public TbItemImage ItemImages { get; set; }
        public List<TbItem> UpSellItems { get; set; }



    }
}
