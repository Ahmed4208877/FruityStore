using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbItemImages = new HashSet<TbItemImage>();
            TbPurchaseInvoiceItems = new HashSet<TbPurchaseInvoiceItem>();
            TbSalesInvoiceItems = new HashSet<TbSalesInvoiceItem>();
            TbItemDiscounts = new HashSet<TbItemDiscount>();

        }

        public int ItemId { get; set; }
        [Required(ErrorMessage = "Please enter Item Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please enter SalesPrice ")]
        public decimal SalesPrice { get; set; }
        [Required(ErrorMessage = "Please enter PurchasePrice")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Please select Category Name")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter Quantity")]
        public int Quantity { get; set; }
        [MaxLength(200)]
        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; }
        public virtual ICollection<TbItemImage> TbItemImages { get; set; }
        public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
        public virtual ICollection<TbCustomerItems> TbCustomerItems { get; set; }
    }
}
