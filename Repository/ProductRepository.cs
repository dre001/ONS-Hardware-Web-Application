using Microsoft.EntityFrameworkCore;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }
        public bool Create(Product entity)
        {
            _db.Products.Add(entity);
            //Save
            return Save();

        }

        public bool Delete(Product entity)
        {
            _db.Products.Remove(entity);
            //Save
            return Save();
        }

        public ICollection<Product> FindAll()
        {
            var Supplier = _db.Products
                .Include(q => q.Supplier)
                .ToList();
            return Supplier;
            // return _db.Products.ToList();
            // Products = _db.Products.ToList();
            //return view (Products);
        }

        public Product FindById(int id)
        {
            var Supplier = _db.Products
                .Include(q => q.Supplier)
                .FirstOrDefault(q => q.Id == id);
            return Supplier;
            //var Product = _db.Products.Find(Id);
            //return Product;
        }

        public bool isExists(int Id)
        {
            var exists = _db.Products.Any(q => q.Id == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Product entity)
        {
            _db.Products.Update(entity);
            //Save
            return Save();
        }
    }
}
