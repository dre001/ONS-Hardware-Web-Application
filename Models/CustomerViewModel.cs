﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
       
        public ParishViewModel Parish { get; set; }
        public int ParishId { get; set; }
        public IEnumerable<SelectListItem> Parishes { get; set; } //Drop Down list for Parishes
    }
}