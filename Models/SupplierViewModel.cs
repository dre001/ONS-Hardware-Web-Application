//using ONS_Hardware_Web_Application.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public ParishViewModel Parish { get; set; }
        public int ParishId { get; set; }
        public bool? Approved { get; set; } //last thing added
        public IEnumerable<SelectListItem> Parishes { get; set; } //Drop Down list for Parishes
     }
    //public class DeliveryStatusViewModel
    //{
    //    public int TotalDelivery { get; set; }
    //    public int PendingDelivery { get; set; }
    //    public int NotDelivered { get; set; }
        
    //}
}
