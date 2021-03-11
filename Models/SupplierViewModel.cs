﻿//using ONS_Hardware_Web_Application.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class DetailsSupplierViewModel
    {
        public int Id { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public ParishViewModel Parish { get; set; }
        public int ParishId { get; set; }
        public IEnumerable<SelectListItem> Parishes { get; set; } //Drop Down list for Parishes

        public class CreateSupplierViewModel
        {

            [Required]
            public string CompanyName { get; set; }
        }
    }
}
