using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Data
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [ForeignKey("ParishId")]
        public Parish Parish { get; set; }
        public int ParishId { get; set; }
    }
}
