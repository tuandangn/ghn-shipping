using GhnShipping.Domain.Directory;
using GhnShipping.Models.Directory;

namespace GhnShipping.Tests.Helpers
{
    public static class ModelExtensions
    {
        public static ProvinceModel ToModel(this Province province)
        {
            return new ProvinceModel
            {
                Id = province.Id,
                Name = province.Name
            };
        }

        public static DistrictModel ToModel(this District district)
        {
            return new DistrictModel
            {
                Id = district.Id,
                Name = district.Name
            };
        }

        public static WardModel ToModel(this Ward ward)
        {
            return new WardModel
            {
                Id = ward.Id,
                Name = ward.Name
            };
        }
    }
}
