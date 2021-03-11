using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Repository
{
    public class ParishRepository : IParishRepository
    {
        private readonly ApplicationDbContext _db;
        public ParishRepository(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }
        public bool Create(Parish entity)
        {
            _db.Parishes.Add(entity);
            //Save
            return Save();
            //Save
        }

        public bool Delete(Parish entity)
        {
            _db.Parishes.Remove(entity);
            //Save
            return Save();
        }

        public ICollection<Parish> FindAll()
        {
            return _db.Parishes.ToList();
            
        }

        public Parish FindById(int Id)
        {
            var Parish = _db.Parishes.Find(Id);
            return Parish;
        }

        public bool isExists(int Id)
        {
            var exists = _db.Parishes.Any(q => q.Id == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Parish entity)
        {
            _db.Parishes.Update(entity);
            //Save
            return Save();
        }
    }
}
