using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbItem = new HashSet<TbItem>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TbItem> TbItem { get; set; }

    }
}
