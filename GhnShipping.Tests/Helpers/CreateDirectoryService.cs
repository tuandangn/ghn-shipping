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
    }
}
