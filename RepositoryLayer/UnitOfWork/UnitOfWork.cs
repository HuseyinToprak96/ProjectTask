using CoreLayer.Interfaces.UnitOfWork;
using RepositoryLayer.IdentityDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDbContext _dbContext;
        public UnitOfWork(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
