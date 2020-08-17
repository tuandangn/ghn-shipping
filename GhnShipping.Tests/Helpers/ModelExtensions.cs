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
    }
}
