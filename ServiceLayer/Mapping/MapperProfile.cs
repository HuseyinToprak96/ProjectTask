using AutoMapper;
using CoreLayer.Dtos.Complaint;
using CoreLayer.Dtos.Herb;
using CoreLayer.Entities.ComplaintEntity;
using CoreLayer.Entities.HerbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Herb, HerbDto>().ReverseMap();
            CreateMap<Complaint, ComplaintDto>().ReverseMap();
            CreateMap<Herb, HerbDetailDto>().ForMember(x => x.Complaints, opt => opt.MapFrom(x => x.ComplaintHerbs.Select(x => x.Complaint)));
        }
    }
}
