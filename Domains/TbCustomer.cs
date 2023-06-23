using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbSalesInvoices = new HashSet<TbSalesInvoice>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<TbSalesInvoice> TbSalesInvoices { get; set; }
        public virtual ICollection<TbCustomerItems> TbCustomerItems { get; set; }
        public virtual TbBusniessInfo BusniessInfo { get; set; }





    }
}
