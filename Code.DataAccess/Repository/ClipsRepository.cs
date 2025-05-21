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
    public class ClipsRepository : Repository<Clips> , IClipsRepository 
    {
        private ApplicationDbContext _db;
        public ClipsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }
        public void Update(Clips clips)
        {
            _db.Movies.Update(clips);
        }
    }
}
