using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helper;

namespace React.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AtmCrs, AtmCrsVM>().ReverseMap();
         
        }
    }
}
