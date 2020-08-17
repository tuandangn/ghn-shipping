using GhnShipping.Domain.Directory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GhnShipping.Services
{
    public interface IDirectoryService
    {
        public Task<IList<Province>> GetProvincesAsync();

        public Task<IList<District>> GetDistrictsAsync(int provinceId);

        public Task<IList<Ward>> GetWardsAsync(int districtId);
    }
}
