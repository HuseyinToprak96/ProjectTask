using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
    public interface IService<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T Tentity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> Entities);
        Task Remove(T Tentity);
        Task RemoveRange(IEnumerable<T> Entities);
        Task Update(T Tentity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
