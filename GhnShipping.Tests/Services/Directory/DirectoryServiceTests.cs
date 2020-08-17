using GhnShipping.Domain.Directory;
using GhnShipping.Infrastructure.Directory;
using GhnShipping.Tests.Helpers;
using GhnShipping.Tests.Helpers.Options;
using System;
using System.Collections.Generic;
using Xunit;

namespace GhnShipping.Tests.Services.Directory
{
    public class DirectoryServiceTests
    {
        #region GetProvincesAsync
        [Fact]
        public async void GetProvincesAsync_ErrorResponse_ThrowException()
        {
            var url = "error response url";
            var clientServiceMock = CreateClientService.WhenGet(url)
                .ReturnError<List<Province>>("error")
                .Build();
            var urlSettingsAccessorMock = CreateOption.ForUrlSettings()
                .ProvinceUrl(url)
                .Build();
            var directoryService = new DirectoryService(clientServiceMock.Object, urlSettingsAccessorMock.Object);

            await Assert.ThrowsAsync<Exception>(() => directoryService.GetProvincesAsync());

            urlSettingsAccessorMock.Verify();
            clientServiceMock.Verify();
        }

        [Fact]
        public async void GetProvincesAsync_SuccessResponse_ReturnData()
        {
            var url = "success response url";
            var data = new[] { new Province { Id = 1 }, new Province { Id = 2 } };
            var clientServiceStub = CreateClientService.WhenGet(url)
                .Return(data)
                .Build();
            var urlSettingsAccessorStub = CreateOption.ForUrlSettings()
                .ProvinceUrl(url)
                .Build();
            var directoryService = new DirectoryService(clientServiceStub.Object, urlSettingsAccessorStub.Object);

            var provincesResult = await directoryService.GetProvincesAsync();

            Assert.Equal(data, provincesResult);
        }
        #endregion
    }
}
