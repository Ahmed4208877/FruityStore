using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
namespace fruity.Models
{
    public class HomePageModel
    {
        public IEnumerable<TbItem> lisItem;
        public IEnumerable<TbCategory> lisCategory;
    }
}
