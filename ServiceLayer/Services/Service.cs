using AutoMapper;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using CoreLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IGenericRepository<T> _genericRepository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T Tentity)
        {
           await _genericRepository.AddAsync(Tentity);
           await _unitOfWork.CommitAsync();
            return Tentity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> Entities)
        {
            await _genericRepository.AddRangeAsync(Entities);
            await _unitOfWork.CommitAsync();
            return Entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task Remove(T Tentity)
        {
            _genericRepository.Remove(Tentity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRange(IEnumerable<T> Entities)
        {
            _genericRepository.RemoveRange(Entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(T Tentity)
        {
            _genericRepository.Update(Tentity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
             return _genericRepository.Where(expression);
        }
    }
}
