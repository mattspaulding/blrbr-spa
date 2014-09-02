using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class SignUp
    {
        public int SignUpId { get; set; }
        [Required]
        [Display(Name="twitter")]
        public string TwitterHandle { get; set; }
        [Display(Name = "name")]
        public string Name { get; set; }
        [EmailAddress]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "comment")]
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}