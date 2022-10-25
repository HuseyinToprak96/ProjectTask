using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T Tentity);
        Task AddRangeAsync(IEnumerable<T> Entities);
        void Remove(T Tentity);
        void RemoveRange(IEnumerable<T> Entities);
        void Update(T Tentity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
