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
            return _db.Customers.ToList();
        }

        public Customer FindById(int Id)
        {
            var Customer = _db.Customers.Find(Id);
            return Customer;
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
