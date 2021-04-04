using AutoMapper;
using ONS_Hardware_Web_Application.Data;
using ONS_Hardware_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ONS_Hardware_Web_Application.Models.SupplierViewModel;

namespace ONS_Hardware_Web_Application.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Supplier, SupplierViewModel>().ReverseMap(); //Reverse Map Is data flowing in both directions
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Purchase, PurchaseViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Parish, ParishViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap(); //Last one that was added
            CreateMap<Supplier, DeliveryStatusViewModel>().ReverseMap(); //Last one that was added
           // CreateMap<Employee, EditEmployeeViewModel>().ReverseMap(); //Last one that was added
        }
    }
}
