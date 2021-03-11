using AutoMapper;
using ONS_Hardware_Web_Application.Data;
using ONS_Hardware_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ONS_Hardware_Web_Application.Models.DetailsSupplierViewModel;

namespace ONS_Hardware_Web_Application.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Supplier, DetailsSupplierViewModel>().ReverseMap(); //Reverse Map Is data flowing in both directions
            CreateMap<Supplier, CreateSupplierViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Purchase, PurchaseViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Parish, ParishViewModel>().ReverseMap();
            
        }
    }
}
