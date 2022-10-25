using CoreLayer.Dtos;
using CoreLayer.Dtos.Herb;
using CoreLayer.Entities.HerbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service.Herb
{
    public interface IHerbService:IService<CoreLayer.Entities.HerbEntity.Herb>
    {
        Task<CustomResponseDto<HerbDetailDto>> GetDetail(int id);
        Task<CustomResponseDto<IEnumerable<HerbDto>>> AllDetail();
        Task RemoveUpdate(int id);
    }
}
