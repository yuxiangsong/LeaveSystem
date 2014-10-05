using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LeaveSystemDomain.Entities
{
    public class Person
    {
        [Required]
        [Display(Name = "User Name")]
        [Remote("ValidateName", "Home")]
        public string Name { get; set; }
    }
}
