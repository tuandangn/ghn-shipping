using GhnShipping.Domain.Directory;
using GhnShipping.Infrastructure.Network;
using GhnShipping.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GhnShipping.Infrastructure.Directory
{
    public sealed class DirectoryService : IDirectoryService
    {
        private readonly IClientService _clientService;
        private readonly IOptionsSnapshot<UrlSettings> _urlOptionAccessor;

        public DirectoryService(IClientService clientService, IOptionsSnapshot<UrlSettings> urlOptionAccessor)
        {
            _clientService = clientService;
            _urlOptionAccessor = urlOptionAccessor;
        }

        public UrlSettings Urls => _urlOptionAccessor.Value;

        public async Task<IList<District>> GetDistrictsAsync(int provinceId)
        {
            var districtUrl = Urls.District;
            var requestUrl = GetRequestDistrictUrl(districtUrl, provinceId);
            var districtsResponse = await _clientService.GetAsync<List<District>>(requestUrl).ConfigureAwait(false);

            if (districtsResponse.Successed)
            {
                return districtsResponse.Data;
            }
            throw new Exception(districtsResponse.Message);

            #region LocalMethods
            string GetRequestDistrictUrl(string url, int provinceId)
                => $"{url}?province_id={provinceId}";

            #endregion
        }

        public async Task<IList<Province>> GetProvincesAsync()
        {
            var provinceUrl = Urls.Province;
            var provincesResponse = await _clientService.GetAsync<List<Province>>(provinceUrl).ConfigureAwait(false);

            if (provincesResponse.Successed)
                return provincesResponse.Data;
            throw new Exception(provincesResponse.Message);
        }

        public async Task<IList<Ward>> GetWardsAsync(int districtId)
        {
            var wardUrl = Urls.Ward;
            var requestUrl = GetWardRequestUrl(wardUrl, districtId);
            var wardResponse = await _clientService.GetAsync<List<Ward>>(requestUrl).ConfigureAwait(false);

            if (wardResponse.Successed)
            {
                return wardResponse.Data;
            }
            throw new Exception(wardResponse.Message);

            #region LocalMethods
            string GetWardRequestUrl(string url, int districtId)
                => $"{url}?district_id={districtId}";

            #endregion
        }
    }
}
