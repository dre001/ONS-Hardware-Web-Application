using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class ParishViewModel
    {
        public int Id { get; set; }
        //public ParishViewModel ParishName { get; set; }
        [Required]
        public string Parishes { get; set; }
      
    }
}
