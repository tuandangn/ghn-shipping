using AutoMapper;
using GhnShipping.Domain.Directory;
using GhnShipping.Models.Directory;

namespace GhnShipping.Infrastructure.Mapper
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Province, ProvinceModel>();

            CreateMap<District, DistrictModel>();

            CreateMap<Ward, WardModel>();
        }
    }
}
