using Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DataAccess.Repository.IRepository
{
    public interface IClipsRepository : IRepository<Clips>
    {
        void Update(Clips clips);
    }
}
