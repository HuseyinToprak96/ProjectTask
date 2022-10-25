using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Dtos.Herb;
using CoreLayer.Entities.HerbEntity;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Repository.HerbRepository;
using CoreLayer.Interfaces.Service.Herb;
using CoreLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class HerbService : Service<Herb>, IHerbService
    {
        private readonly IHerbRepository _herbRepository;
        public HerbService(IGenericRepository<Herb> genericRepository, IMapper mapper, IUnitOfWork unitOfWork,IHerbRepository herbRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _herbRepository = herbRepository;
        }

        public async Task<CustomResponseDto<IEnumerable<HerbDto>>> AllDetail()
        {
            return CustomResponseDto<IEnumerable<HerbDto>>.success(200,_mapper.Map<IEnumerable<HerbDto>>(await _herbRepository.AllDetail()));
        }

        public async Task<CustomResponseDto<HerbDetailDto>> GetDetail(int id)
        {
            return CustomResponseDto<HerbDetailDto>.success(200, _mapper.Map<HerbDetailDto>(await _herbRepository.GetDetail(id)));
        }

        public async Task RemoveUpdate(int id)
        {
            var herb = await _herbRepository.GetByIdAsync(id);
            herb.IsDeleted = true;
            _herbRepository.Update(herb);
            await _unitOfWork.CommitAsync();
        }
    }
}
