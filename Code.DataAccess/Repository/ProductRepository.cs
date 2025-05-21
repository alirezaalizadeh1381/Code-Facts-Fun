using Code.DataAccess.Repository.IRepository;
using Code.Models;
using Code.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DataAccess.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository 
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }
        public void Update(Product products)
        {
            _db.Products.Update(products);
        }
    }
}
