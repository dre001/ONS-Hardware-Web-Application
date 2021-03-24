using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class EmployeeViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address_1 { get; set; }
        [Display(Name = "City")]
        public string Address_2 { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
