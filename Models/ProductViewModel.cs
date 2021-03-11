using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Product Category")]
        public string ProductCategory { get; set; }
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Unit Cost")]
        [Required]
        public decimal UniitCost { get; set; }
        [Required]
        public int Qantity { get; set; }
        [Display(Name = "Product Location")]
        public string ProductLocation { get; set; }

        public SupplierViewModel Supplier { get; set; }
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; } //Drop Down list for Supplier
    }
}
