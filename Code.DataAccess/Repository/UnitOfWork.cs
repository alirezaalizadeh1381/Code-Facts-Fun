using Code.DataAccess.Data;
using Code.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DataAccess.Repository
{
    public class UnitOf_Work : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IClipsRepository clips { get; private set; }
        public IProductRepository product { get; private set; }
        public UnitOf_Work(ApplicationDbContext db)
        {
            _db = db;
            clips = new  ClipsRepository(db);
            product = new ProductRepository(db);

        }
      
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
