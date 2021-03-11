using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;
        public PurchaseRepository(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }
        public bool Create(Purchase entity)
        {
            _db.Purchasers.Add(entity);
            //Save
            return Save();
        }

        public bool Delete(Purchase entity)
        {
            _db.Purchasers.Remove(entity);
            //Save
            return Save();
        }

        public ICollection<Purchase> FindAll()
        {
            return _db.Purchasers.ToList();
        }

        public Purchase FindById(int Id)
        {
            var Purchase = _db.Purchasers.Find(Id);
            return Purchase;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Purchase entity)
        {
            _db.Purchasers.Update(entity);
            //Save
            return Save();
        }
    }
}
