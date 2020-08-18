using GhnShipping.Domain.Directory;
using GhnShipping.Infrastructure.Directory;
using Moq;
using System;

namespace GhnShipping.Tests.Helpers
{
    public static class CreateDirectoryService
    {
        public static IDirectoryService Default => Mock.Of<IDirectoryService>();

        public static GetProvincesMethodBuilder WhenGetProvinces()
        {
            var builder = new DirectoryServiceBuilder();
            return builder.WhenGetProvinces();
        }

        public static GetDistrictsMethodBuilder WhenGetDistricts()
        {
            var builder = new DirectoryServiceBuilder();
            return builder.WhenGetDistricts();
        }

        public static GetWardsMethodBuilder WhenGetWards()
        {
            var builder = new DirectoryServiceBuilder();
            return builder.WhenGetWards();
        }

        public sealed class DirectoryServiceBuilder
        {
            private readonly Mock<IDirectoryService> _directoryServiceMock;

            public DirectoryServiceBuilder()
            {
                _directoryServiceMock = new Mock<IDirectoryService>();
            }

            public GetProvincesMethodBuilder WhenGetProvinces()
            {
                var methodBuilder = new GetProvincesMethodBuilder(this, _directoryServiceMock);
                return methodBuilder;
            }

            public GetDistrictsMethodBuilder WhenGetDistricts()
            {
                var methodBuilder = new GetDistrictsMethodBuilder(this, _directoryServiceMock);
                return methodBuilder;
            }

            public GetWardsMethodBuilder WhenGetWards()
            {
                var methodBuilder = new GetWardsMethodBuilder(this, _directoryServiceMock);
                return methodBuilder;
            }

            public Mock<IDirectoryService> Build() => _directoryServiceMock;
        }

        public sealed class GetProvincesMethodBuilder
        {
            private readonly DirectoryServiceBuilder _builder;
            private readonly Mock<IDirectoryService> _mock;

            public GetProvincesMethodBuilder(DirectoryServiceBuilder builder, Mock<IDirectoryService> mock)
            {
                _builder = builder;
                _mock = mock;
            }

            public DirectoryServiceBuilder Returns(params Province[] provinces)
            {
                _mock.Setup(directoryService => directoryService.GetProvincesAsync())
                    .ReturnsAsync(provinces)
                    .Verifiable();

                return _builder;
            }

            public DirectoryServiceBuilder ThrowError(string message)
            {
                _mock.Setup(directoryService => directoryService.GetProvincesAsync())
                    .ThrowsAsync(new Exception(message))
                    .Verifiable();

                return _builder;
            }
        }

        public sealed class GetWardsMethodBuilder
        {
            private readonly DirectoryServiceBuilder _builder;
            private readonly Mock<IDirectoryService> _mock;

            private int _districtId;

            public GetWardsMethodBuilder(DirectoryServiceBuilder builder, Mock<IDirectoryService> mock)
            {
                _builder = builder;
                _mock = mock;
            }

            public GetWardsMethodBuilder InDistrict(int districtId)
            {
                _districtId = districtId;
                return this;
            }

            public DirectoryServiceBuilder Returns(params Ward[] wards)
            {
                _mock.Setup(directoryService => directoryService.GetWardsAsync(_districtId))
                    .ReturnsAsync(wards)
                    .Verifiable();

                return _builder;
            }

            public DirectoryServiceBuilder ThrowError(string message)
            {
                _mock.Setup(directoryService => directoryService.GetWardsAsync(_districtId))
                    .ThrowsAsync(new Exception(message))
                    .Verifiable();

                return _builder;
            }
        }

        public sealed class GetDistrictsMethodBuilder
        {
            private readonly DirectoryServiceBuilder _builder;
            private readonly Mock<IDirectoryService> _mock;

            private int _provinceId;

            public GetDistrictsMethodBuilder(DirectoryServiceBuilder builder, Mock<IDirectoryService> mock)
            {
                _builder = builder;
                _mock = mock;
            }

            public GetDistrictsMethodBuilder InProvince(int provinceId)
            {
                _provinceId = provinceId;
                return this;
            }

            public DirectoryServiceBuilder Returns(params District[] districts)
            {
                _mock.Setup(directoryService => directoryService.GetDistrictsAsync(_provinceId))
                    .ReturnsAsync(districts)
                    .Verifiable();

                return _builder;
            }

            public DirectoryServiceBuilder ThrowError(string message)
            {
                _mock.Setup(directoryService => directoryService.GetDistrictsAsync(_provinceId))
                    .ThrowsAsync(new Exception(message))
                    .Verifiable();

                return _builder;
            }
        }
    }
}
