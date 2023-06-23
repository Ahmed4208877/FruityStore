using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class TbBusniessInfo
    {
        [Key]
        public int BusniessInfoId { get; set; }
        public int BusniesssCardNum { get; set; }
        public string officePhone { get; set; }
        public decimal Budget { get; set; }
        public int CustomerId { get; set; }
        public virtual TbCustomer Customer { get; set; } 

    }

}
