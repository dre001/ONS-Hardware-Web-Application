using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _db;
        public SupplierRepository(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }
        public bool Create(Supplier entity)
        {
            _db.Suppliers.Add(entity);
            //Save
            return Save();
        }

        public bool Delete(Supplier entity)
        {
            _db.Suppliers.Remove(entity);
            //Save
            return Save();
        }

        public ICollection<Supplier> FindAll()
        {
         return _db.Suppliers.ToList();
            
            //or
         //var Suppliers = _db.Suppliers.ToList();

         //  return Suppliers;
        }

        public Supplier FindById(int Id)
        {
            var Supplier =_db.Suppliers.Find(Id);
            return Supplier;
            
        }

        public ICollection<Supplier> GetSupplierType(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
            
        }

        public bool Update(Supplier entity)
        {
            _db.Suppliers.Update(entity);
            //Save
            return Save();
        }
    }
}
