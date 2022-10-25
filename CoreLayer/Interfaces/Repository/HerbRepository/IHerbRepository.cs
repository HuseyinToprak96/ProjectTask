using CoreLayer.Entities.HerbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository.HerbRepository
{
    public interface IHerbRepository:IGenericRepository<Herb>
    {
        Task<Herb> GetDetail(int id);
        Task<IEnumerable<Herb>> AllDetail();
    }
}
