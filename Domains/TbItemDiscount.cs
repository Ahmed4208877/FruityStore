using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public class TbItemDiscount
    {
       
        [Key]
        public int ItemDiscountId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]

        public decimal DiscountPresent { get; set; }
        [Required]

        public DateTime EndDate { get; set; }

        public virtual TbItem Item { get; set; }

    }
}
