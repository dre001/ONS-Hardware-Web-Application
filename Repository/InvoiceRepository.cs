using Microsoft.EntityFrameworkCore;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;
        public InvoiceRepository(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }
        public bool Create(Invoice entity)
        {
            _db.Invoices.Add(entity);
            //Save
            return Save();
        }

       
        public bool Delete(Invoice entity)
        {
            _db.Invoices.Remove(entity);
            //Save
            return Save();
        }


        public ICollection<Invoice> FindAll()
        {
            var product = _db.Invoices
               .Include(q => q.Product)       //To associate ID numbers to there respective Names
               .ToList();

            var customer = _db.Invoices
                  .Include(q => q.Customer)       //To associate ID numbers to there respective Names
                  .ToList();
            
            var model = product;
                model = customer;
           
            return model;

        }


        public Invoice FindById(int Id)
        {
            var product = _db.Invoices
                .Include(q => q.Product)
                .FirstOrDefault(q => q.Id == Id); //To associate ID numbers to there respective Names
            //return product;
            
            var customer = _db.Invoices
                .Include(q => q.Customer)
                .FirstOrDefault(q => q.Id == Id); //To associate ID numbers to there respective Names
                                                  // return product;

            var model = product;
                model = customer;

            return model;

            //var Invoice = _db.Invoices.Find(Id);
            //return Invoice;
        }

        public bool isExists(int Id)
        {
            var exists = _db.Invoices.Any(q => q.Id == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Invoice entity)
        {
            _db.Invoices.Update(entity);
            //Save
            return Save();
        }
    }
}
