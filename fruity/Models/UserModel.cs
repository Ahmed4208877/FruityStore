using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fruity.Models
{
    public class UserModel
    {
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Returnurl { get; set; }



    }
}
