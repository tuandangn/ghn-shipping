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

        public static GetAsyncMethodBuilder WhenGet(string url)
        {
            var builder = new ClientServiceBuilder();
            return builder.WhenGet(url);
        }

        public static GetAsyncMethodBuilder WhenPost(string url)
        {
            var builder = new ClientServiceBuilder();
            return builder.WhenGet(url);
        }

        public sealed class ClientServiceBuilder
        {
            private readonly Mock<IClientService> _clientServiceMock;

            public ClientServiceBuilder()
            {
                _clientServiceMock = new Mock<IClientService>();
            }

            public GetAsyncMethodBuilder WhenGet(string url)
            {
                var getMethodBuilder = new GetAsyncMethodBuilder(this, _clientServiceMock);
                return getMethodBuilder.WhenGet(url);
            }

            public PostAsyncMethodBuilder WhenPost(string url)
            {
                var postMethodBuilder = new PostAsyncMethodBuilder(this, _clientServiceMock);
                return postMethodBuilder.WhenPost(url);
            }

            public Mock<IClientService> Build() => _clientServiceMock;

        }

        public sealed class GetAsyncMethodBuilder
        {
            private readonly ClientServiceBuilder _builder;
            private readonly Mock<IClientService> _mock;
            private string _url;

            public GetAsyncMethodBuilder(ClientServiceBuilder builder, Mock<IClientService> mock)
            {
                _mock = mock;
                _builder = builder;
            }

            public GetAsyncMethodBuilder WhenGet(string url)
            {
                _url = url;
                return this;
            }

            public ClientServiceBuilder Return<TResult>(params TResult[] result)
            {
                var successResponse = new ApiResponse<List<TResult>> { Code = 200, Data = result.ToList() };
                _mock.Setup(clientService => clientService.GetAsync<List<TResult>>(_url))
                    .ReturnsAsync(successResponse)
                    .Verifiable();

                return _builder;
            }

            public ClientServiceBuilder ReturnError<TResult>(string message)
            {
                var errorResponse = new ApiResponse<TResult> { Message = message };
                _mock.Setup(clientService => clientService.GetAsync<TResult>(_url))
                    .ReturnsAsync(errorResponse)
                    .Verifiable();

                return _builder;
            }
        }

        public sealed class PostAsyncMethodBuilder
        {
            private readonly ClientServiceBuilder _builder;
            private readonly Mock<IClientService> _mock;
            private string _url;
            private object _payload;

            public PostAsyncMethodBuilder(ClientServiceBuilder builder, Mock<IClientService> mock)
            {
                _mock = mock;
                _builder = builder;
            }

            public PostAsyncMethodBuilder WhenPost(string url)
            {
                _url = url;
                return this;
            }

            public PostAsyncMethodBuilder WithData(object payload)
            {
                _payload = payload;
                return this;
            }

            public ClientServiceBuilder Return<TResult>(params TResult[] result)
            {
                var successResponse = new ApiResponse<List<TResult>> { Code = 200, Data = result.ToList() };
                _mock.Setup(clientService => clientService.PostAsync<List<TResult>>(_url, _payload))
                    .ReturnsAsync(successResponse)
                    .Verifiable();

                return _builder;
            }

            public ClientServiceBuilder ReturnError<TResult>(string message)
            {
                var errorResponse = new ApiResponse<TResult> { Message = message };
                _mock.Setup(clientService => clientService.PostAsync<TResult>(_url, _payload))
                    .ReturnsAsync(errorResponse)
                    .Verifiable();

                return _builder;
            }
        }
    }
}
