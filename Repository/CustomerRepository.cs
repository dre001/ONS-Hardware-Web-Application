using Microsoft.EntityFrameworkCore;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }
        public bool Create(Customer entity)
        {
            _db.Customers.Add(entity);
            //Save
            return Save();

        }

        public bool Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
            //Save
            return Save();
        }

        public ICollection<Customer> FindAll()
        {
            var Parish = _db.Customers
                .Include(q => q.Parish)       //To associate ID numbers to there respective Names
                .ToList();
            return Parish;
            // return _db.Customers.ToList();
        }

        public Customer FindById(int Id)
        {

            var Parish = _db.Customers
                .Include(q => q.Parish)
                .FirstOrDefault(q => q.Id == Id); //To associate ID numbers to there respective Names
            return Parish;
            //var Customer = _db.Customers.Find(Id);
            //return Customer;
        }

        public bool isExists(int Id)
        {
            var exists = _db.Customers.Any(q => q.Id == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Customer entity)
        {
            _db.Customers.Update(entity);
            //Save
            return Save();
        }
    }
}
