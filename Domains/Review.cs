using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        public string RName { get; set; }
        [Required(ErrorMessage = "Please enter your E-mail")]
        public string REmail { get; set; }
        [Required(ErrorMessage = "Please enter your Phone")]
        public string RPhone { get; set; }
        [Required(ErrorMessage = "Please enter Subject")]
        public string RSubject { get; set; }
        [Required(ErrorMessage = "Please enter Message")]
        public string RMessage { get; set; }



    }
}
