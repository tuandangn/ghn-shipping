using GhnShipping.Domain;
using GhnShipping.Infrastructure.Network;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace GhnShipping.Tests.Helpers
{
    public static class CreateClientService
    {
        public static IClientService Default => Mock.Of<IClientService>();

        public static ClientServiceBuilder WhenGet(string url)
        {
            var builder = new ClientServiceBuilder();
            return builder.WhenGet(url);
        }

        public sealed class ClientServiceBuilder
        {
            private readonly Mock<IClientService> _clientServiceMock;
            private string _tempUrl;

            public ClientServiceBuilder()
            {
                _clientServiceMock = new Mock<IClientService>();
            }

            public ClientServiceBuilder WhenGet(string url)
            {
                _tempUrl = url;
                return this;
            }

            public ClientServiceBuilder ReturnError<TResult>(string message)
            {
                var errorResponse = new ApiResponse<TResult> { Message = message };
                _clientServiceMock.Setup(clientService => clientService.GetAsync<TResult>(_tempUrl))
                    .ReturnsAsync(errorResponse)
                    .Verifiable();

                return this;
            }
            public ClientServiceBuilder Return<TResult>(params TResult[] data)
            {
                var successResponse = new ApiResponse<List<TResult>> { Code = 200, Data = data.ToList() };
                _clientServiceMock.Setup(clientService => clientService.GetAsync<List<TResult>>(_tempUrl))
                    .ReturnsAsync(successResponse)
                    .Verifiable();

                return this;
            }

            public Mock<IClientService> Build() => _clientServiceMock;
        }
    }
}
