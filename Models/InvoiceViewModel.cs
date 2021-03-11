using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class InvoiceViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitCost { get; set; }
        public Decimal TotalCost { get; set; }
        [Required]
        public EmployeeViewModel Employee { get; set; }
        public string EmployeesId { get; set; }
        
        public int Customer { get; set; }
        public int CustomerId { get; set; }
      
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
