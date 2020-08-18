using GhnShipping.Controllers;
using GhnShipping.Domain.Directory;
using GhnShipping.Tests.Helpers;
using GhnShipping.Tests.Helpers.Mappers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GhnShipping.Tests.Controllers
{
    public class DirectoryControllerTests
    {
        #region GetProvincesAsync
        [Fact]
        public async void GetProvinceAsync_WhenError_BadRequestResult()
        {
            var directoryServiceMock = CreateDirectoryService.WhenGetProvinces()
                .ThrowError("error")
                .Build();
            var directoryController = new DirectoryController(directoryServiceMock.Object, CreateMapper.Default);

            var actionResult = await directoryController.GetProvincesAsync();

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("error", badRequestResult.Value);
            directoryServiceMock.Verify();
        }

        [Fact]
        public async void GetProvinceAsync_WhenSuccess_OkResult()
        {
            var provinces = new[] { new Province { Id = 1 }, new Province { Id = 2 } };
            var directoryServiceStub = CreateDirectoryService.WhenGetProvinces()
                .Returns(provinces)
                .Build();
            var mapperMock = CreateMapper
                .WhenMap(provinces[0]).Return(provinces[0].ToModel())
                .WhenMap(provinces[1]).Return(provinces[1].ToModel())
                .Build();
            var directoryController = new DirectoryController(directoryServiceStub.Object, mapperMock.Object);

            var actionResult = await directoryController.GetProvincesAsync();

            var provincesResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            dynamic provinceModels = provincesResult.Value;
            Assert.Equal(1, provinceModels[0].Id);
            Assert.Equal(2, provinceModels[1].Id);
            mapperMock.Verify();
        }

        #endregion

        #region GetDistrictsInProvinceAsync
        [Fact]
        public async void GetDistrictInProvinceAsync_WhenError_BadRequestResult()
        {
            var directoryServiceMock = CreateDirectoryService.WhenGetDistricts()
                .InProvince(-1)
                .ThrowError("error")
                .Build();
            var directoryController = new DirectoryController(directoryServiceMock.Object, CreateMapper.Default);

            var actionResult = await directoryController.GetDistrictsInProvinceAsync(-1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("error", badRequestResult.Value);
            directoryServiceMock.Verify();
        }

        [Fact]
        public async void GetDistrictInProvinceAsync_WhenSuccess_OkResult()
        {
            var districts = new[] { new District { Id = 1 }, new District { Id = 2 } };
            var directoryServiceStub = CreateDirectoryService.WhenGetDistricts()
                .InProvince(1)
                .Returns(districts)
                .Build();
            var mapperMock = CreateMapper
                .WhenMap(districts[0]).Return(districts[0].ToModel())
                .WhenMap(districts[1]).Return(districts[1].ToModel())
                .Build();
            var directoryController = new DirectoryController(directoryServiceStub.Object, mapperMock.Object);

            var actionResult = await directoryController.GetDistrictsInProvinceAsync(1);

            var districtsResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            dynamic districtModels = districtsResult.Value;
            Assert.Equal(1, districtModels[0].Id);
            Assert.Equal(2, districtModels[1].Id);
            mapperMock.Verify();
        }

        #endregion

        #region GetDistrictsAsync
        [Fact]
        public async void GetDistrictAsync_WhenError_BadRequestResult()
        {
            var directoryServiceMock = CreateDirectoryService.WhenGetDistricts()
                .InProvince(0)
                .ThrowError("error")
                .Build();
            var directoryController = new DirectoryController(directoryServiceMock.Object, CreateMapper.Default);

            var actionResult = await directoryController.GetDistrictsAsync();

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("error", badRequestResult.Value);
            directoryServiceMock.Verify();
        }

        [Fact]
        public async void GetDistrictAsync_WhenSuccess_OkResult()
        {
            var districts = new[] { new District { Id = 1 }, new District { Id = 2 } };
            var directoryServiceStub = CreateDirectoryService.WhenGetDistricts()
                .InProvince(0)
                .Returns(districts)
                .Build();
            var mapperMock = CreateMapper
                .WhenMap(districts[0]).Return(districts[0].ToModel())
                .WhenMap(districts[1]).Return(districts[1].ToModel())
                .Build();
            var directoryController = new DirectoryController(directoryServiceStub.Object, mapperMock.Object);

            var actionResult = await directoryController.GetDistrictsAsync();

            var districtsResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            dynamic districtModels = districtsResult.Value;
            Assert.Equal(1, districtModels[0].Id);
            Assert.Equal(2, districtModels[1].Id);
            mapperMock.Verify();
        }

        #endregion

        #region GetWardsInDistrictAsync
        [Fact]
        public async void GetWardsInDistrictAsync_WhenError_BadRequestResult()
        {
            var directoryServiceMock = CreateDirectoryService.WhenGetWards()
                .InDistrict(-1)
                .ThrowError("error")
                .Build();
            var directoryController = new DirectoryController(directoryServiceMock.Object, CreateMapper.Default);

            var actionResult = await directoryController.GetWardsInDistrictAsync(-1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("error", badRequestResult.Value);
            directoryServiceMock.Verify();
        }

        [Fact]
        public async void GetWardsInDistrictAsync_WhenSuccess_OkResult()
        {
            var wards = new[] { new Ward { Id = 1 }, new Ward { Id = 2 } };
            var directoryServiceStub = CreateDirectoryService.WhenGetWards()
                .InDistrict(1)
                .Returns(wards)
                .Build();
            var mapperMock = CreateMapper
                .WhenMap(wards[0]).Return(wards[0].ToModel())
                .WhenMap(wards[1]).Return(wards[1].ToModel())
                .Build();
            var directoryController = new DirectoryController(directoryServiceStub.Object, mapperMock.Object);

            var actionResult = await directoryController.GetWardsInDistrictAsync(1);

            var districtsResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            dynamic districtModels = districtsResult.Value;
            Assert.Equal(1, districtModels[0].Id);
            Assert.Equal(2, districtModels[1].Id);
            mapperMock.Verify();
        }

        #endregion

        #region GetWardsAsync
        [Fact]
        public async void GetWardAsync_WhenError_BadRequestResult()
        {
            var directoryServiceMock = CreateDirectoryService.WhenGetWards()
                .InDistrict(0)
                .ThrowError("error")
                .Build();
            var directoryController = new DirectoryController(directoryServiceMock.Object, CreateMapper.Default);

            var actionResult = await directoryController.GetWardsAsync();

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("error", badRequestResult.Value);
            directoryServiceMock.Verify();
        }

        [Fact]
        public async void GetWardAsync_WhenSuccess_OkResult()
        {
            var wards = new[] { new Ward { Id = 1 }, new Ward { Id = 2 } };
            var directoryServiceStub = CreateDirectoryService.WhenGetWards()
                .InDistrict(0)
                .Returns(wards)
                .Build();
            var mapperMock = CreateMapper
                .WhenMap(wards[0]).Return(wards[0].ToModel())
                .WhenMap(wards[1]).Return(wards[1].ToModel())
                .Build();
            var directoryController = new DirectoryController(directoryServiceStub.Object, mapperMock.Object);

            var actionResult = await directoryController.GetWardsAsync();

            var wardsResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            dynamic wardModels = wardsResult.Value;
            Assert.Equal(1, wardModels[0].Id);
            Assert.Equal(2, wardModels[1].Id);
            mapperMock.Verify();
        }

        #endregion
    }
}
