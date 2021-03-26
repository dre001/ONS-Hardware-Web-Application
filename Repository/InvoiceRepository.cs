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
            var employee = _db.Invoices
               .Include(q => q.Employee)       //To associate ID numbers to there respective Names
               .ToList();
            return employee;
            // return _db.Invoices.ToList();
        }

        public Invoice FindById(int Id)
        {
            var employee = _db.Invoices
                .Include(q => q.Employee)
                .FirstOrDefault(q => q.Id == Id); //To associate ID numbers to there respective Names
            return employee;
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
