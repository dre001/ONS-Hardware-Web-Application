using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Data
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitCost { get; set; }
        public Decimal TotalCost { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeesId { get; set; }
        [ForeignKey("CustomerId")]
        public int Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
