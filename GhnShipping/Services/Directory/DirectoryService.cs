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

        public async Task<IList<District>> GetDistrictsAsync(int provinceId)
        {
            throw new Exception();
        }

        public async Task<IList<Province>> GetProvincesAsync()
        {
            var urlSettings = _urlOptionAccessor.Value;
            var provinceUrl = urlSettings.Province;
            var provincesResponse = await _clientService.GetAsync<List<Province>>(provinceUrl).ConfigureAwait(false);

            if (provincesResponse.Successed)
                return provincesResponse.Data;
            throw new Exception(provincesResponse.Message);
        }

        public Task<IList<Ward>> GetWardsAsync(int districtId)
        {
            throw new System.NotImplementedException();
        }
    }
}
