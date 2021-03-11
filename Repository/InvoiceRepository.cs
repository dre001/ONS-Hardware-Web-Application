﻿using ONS_Hardware_Web_Application.Contracts;
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
            return _db.Invoices.ToList();
        }

        public Invoice FindById(int Id)
        {
            var Invoice = _db.Invoices.Find(Id);
            return Invoice;
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

       
        ICollection<Invoice> IRepositoryBase<Invoice>.FindAll()
        {
            throw new NotImplementedException();
        }

        Invoice IRepositoryBase<Invoice>.FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}