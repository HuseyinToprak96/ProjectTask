using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IdentityDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class GeneralRepository<T> : IGenericRepository<T> where T:class
    {
        protected IdentityDBContext.IdentityDbContext _db;
        private readonly DbSet<T> _dbSet;
        public GeneralRepository(IdentityDBContext.IdentityDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task AddAsync(T Tentity)
        {
            await _dbSet.AddAsync(Tentity);
        }
        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await _dbSet.AddRangeAsync(Entities);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Remove(T Tentity)
        {
            _dbSet.Remove(Tentity);
        }
        public void RemoveRange(IEnumerable<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
        }
        public void Update(T Tentity)
        {
            _dbSet.Update(Tentity);
        }
        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
           return _dbSet.Where(expression);
        }
    }
}