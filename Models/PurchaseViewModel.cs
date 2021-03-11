using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Decimal Cost { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
       
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
    }
}
