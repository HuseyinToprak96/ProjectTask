using CoreLayer.Entities.HerbEntity;
using CoreLayer.Interfaces.Repository.HerbRepository;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IdentityDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class HerbRepository : GeneralRepository<Herb>,IHerbRepository
    {
        public HerbRepository(IdentityDBContext.IdentityDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Herb>> AllDetail()
        {
            return await _db.Herbs.Where(x=>x.IsActive==true&&x.IsDeleted==false).Include(x=>x.ComplaintHerbs).ThenInclude(x=>x.Complaint).ToListAsync();
        }

        public async Task<Herb> GetDetail(int id)
        {
            return await _db.Herbs.Where(x => x.IsActive == true && x.IsDeleted == false && x.Id == id).Include(x=>x.ComplaintHerbs).ThenInclude(x=>x.Complaint).SingleOrDefaultAsync();
        }
    }
}