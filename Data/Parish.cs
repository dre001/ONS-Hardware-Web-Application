using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Data
{
    public class Parish
    {
        [Key]
        public int Id { get; set; }
        public string Parishes { get; set; }
    }
}
