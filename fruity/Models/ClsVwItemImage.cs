using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruity.Models;
namespace fruity.Models
{
    public class ClsVwItemImage
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageName { get; set; }
        public decimal SalesPrice { get; set; }
        public int Quantity { get; set; }
    }
}
