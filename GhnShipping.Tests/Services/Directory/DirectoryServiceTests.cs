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
            var provinceUrl = "province url";
            var urlSettingsAccessorMock = CreateOption.ForUrlSettings()
                .ProvinceUrl(provinceUrl)
                .Build();
            var clientServiceMock = CreateClientService.WhenGet(provinceUrl)
                .ReturnError<List<Province>>("error")
                .Build();
            var directoryService = new DirectoryService(clientServiceMock.Object, urlSettingsAccessorMock.Object);

            await Assert.ThrowsAsync<Exception>(() => directoryService.GetProvincesAsync());

            urlSettingsAccessorMock.Verify();
            clientServiceMock.Verify();
        }

        [Fact]
        public async void GetProvincesAsync_SuccessResponse_ReturnProvinces()
        {
            var provinceUrl = "province url";
            var urlSettingsAccessorStub = CreateOption.ForUrlSettings()
                .ProvinceUrl(provinceUrl)
                .Build();
            var provinces = new[] { new Province { Id = 1 }, new Province { Id = 2 } };
            var clientServiceStub = CreateClientService.WhenGet(provinceUrl)
                .Return(provinces)
                .Build();
            var directoryService = new DirectoryService(clientServiceStub.Object, urlSettingsAccessorStub.Object);

            var provincesResult = await directoryService.GetProvincesAsync();

            Assert.Equal(provinces, provincesResult);
        }
        #endregion

        #region GetDistrictsAsync
        [Fact]
        public async void GetDistrictsAsync_ErrorResponse_ThrowException()
        {
            var districtUrl = "district url";
            var urlSettingsAccessorMock = CreateOption.ForUrlSettings()
                .DistrictUrl(districtUrl)
                .Build();
            var requestUrl = GetDistrictRequestUrl(districtUrl, 0);
            var clientServiceMock = CreateClientService.WhenGet(requestUrl)
                .ReturnError<List<District>>("error")
                .Build();
            var directoryService = new DirectoryService(clientServiceMock.Object, urlSettingsAccessorMock.Object);

            await Assert.ThrowsAsync<Exception>(() => directoryService.GetDistrictsAsync(0));

            urlSettingsAccessorMock.Verify();
            clientServiceMock.Verify();
        }

        [Fact]
        public async void GetDistrictsAsync_SuccessResponse_ReturnDistrictsByProvince()
        {
            var districtUrl = "district url";
            var urlSettingsAccessorStub = CreateOption.ForUrlSettings()
                .DistrictUrl(districtUrl)
                .Build();
            var provinceId = 1;
            var districts = new[] { new District { Id = 1 }, new District { Id = 2 } };
            var requestUrl = GetDistrictRequestUrl(districtUrl, provinceId);
            var clientServiceStub = CreateClientService.WhenGet(requestUrl)
                .Return(districts)
                .Build();
            var directoryService = new DirectoryService(clientServiceStub.Object, urlSettingsAccessorStub.Object);

            var districtsResult = await directoryService.GetDistrictsAsync(provinceId);

            Assert.Equal(districts, districtsResult);
        }

        //*TODO* encapsulate
        private string GetDistrictRequestUrl(string url, int provinceId)
            => $"{url}?province_id={provinceId}";

        #endregion

        #region GetWardsAsync
        [Fact]
        public async void GetWardsAsync_ErrorResponse_ThrowException()
        {
            var wardUrl = "ward url";
            var urlSettingsAccessorMock = CreateOption.ForUrlSettings()
                .WardUrl(wardUrl)
                .Build();
            var requestUrl = GetWardRequestUrl(wardUrl, 0);
            var clientServiceMock = CreateClientService.WhenGet(requestUrl)
                .ReturnError<List<Ward>>("error")
                .Build();
            var directoryService = new DirectoryService(clientServiceMock.Object, urlSettingsAccessorMock.Object);

            await Assert.ThrowsAsync<Exception>(() => directoryService.GetWardsAsync(0));

            urlSettingsAccessorMock.Verify();
            clientServiceMock.Verify();
        }

        [Fact]
        public async void GetWardsAsync_SuccessResponse_ReturnWardsByProvince()
        {
            var wardUrl = "ward url";
            var urlSettingsAccessorStub = CreateOption.ForUrlSettings()
                .WardUrl(wardUrl)
                .Build();
            var provinceId = 1;
            var wards = new[] { new Ward { Id = 1 }, new Ward { Id = 2 } };
            var requestUrl = GetWardRequestUrl(wardUrl, provinceId);
            var clientServiceStub = CreateClientService.WhenGet(requestUrl)
                .Return(wards)
                .Build();
            var directoryService = new DirectoryService(clientServiceStub.Object, urlSettingsAccessorStub.Object);

            var wardsResult = await directoryService.GetWardsAsync(provinceId);

            Assert.Equal(wards, wardsResult);
        }

        //*TODO* encapsulate
        private string GetWardRequestUrl(string url, int districtId)
            => $"{url}?district_id={districtId}";

        #endregion
    }
}
