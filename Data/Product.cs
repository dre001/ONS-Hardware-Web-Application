using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public decimal UniitCost { get; set; }
        public int Qantity { get; set; }
        public string ProductLocation { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
    }
}
