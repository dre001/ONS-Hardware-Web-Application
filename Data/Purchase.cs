using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Data
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Decimal Cost { get; set; }
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
