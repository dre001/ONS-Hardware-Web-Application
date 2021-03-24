using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")] // this makes it appear readable and not camel cased
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address_1 { get; set; }
        [Display(Name = "City")]
        public string Address_2 { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
       
        public ParishViewModel Parish { get; set; }
        public int ParishId { get; set; }
        public IEnumerable<SelectListItem> Parishes { get; set; } //Drop Down list for Parishes
    }
}
