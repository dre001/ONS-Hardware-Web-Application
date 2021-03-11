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
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        [Required]
        public decimal UniitCost { get; set; }
        [Required]
        public int Qantity { get; set; }
        public string ProductLocation { get; set; }

        public DetailsSupplierViewModel Supplier { get; set; }
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; } //Drop Down list for Supplier
    }
}
