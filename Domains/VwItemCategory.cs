using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class VwItemCategory
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public string ImageName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public int Quantity { get; set; }
    }
}
