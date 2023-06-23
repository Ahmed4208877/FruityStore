using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class TbCustomerItems
    {
        public int ItemId { get; set; }
        public int CustomerId { get; set; }
        public virtual TbItem Item { get; set; }
        public virtual TbCustomer Customer { get; set; }
    }
}
