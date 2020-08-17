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
    }
}
