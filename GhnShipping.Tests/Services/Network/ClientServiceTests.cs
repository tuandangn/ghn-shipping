using GhnShipping.Infrastructure.Network;
using GhnShipping.Tests.Helpers;
using System;
using Xunit;

namespace GhnShipping.Tests.Services.Network
{
    public class ClientServiceTests
    {
        [Fact]
        public async void GetAsync_UrlIsEmpty_ThrowArgumentException()
        {
            var clientService = new ClientService(CreateHttpClientFactory.Default, CreateWorkContext.Default);

            await Assert.ThrowsAsync<ArgumentException>(() => clientService.GetAsync<object>(string.Empty));
        }

        [Fact]
        public async void PostAsync_UrlIsEmpty_ThrowArgumentException()
        {
            var clientService = new ClientService(CreateHttpClientFactory.Default, CreateWorkContext.Default);

            await Assert.ThrowsAsync<ArgumentException>(() => clientService.PostAsync<object>(string.Empty, new object()));
        }

        [Fact]
        public async void PostAsync_PayloadIsNull_ThrowArgumentNullException()
        {
            var clientService = new ClientService(CreateHttpClientFactory.Default, CreateWorkContext.Default);

            await Assert.ThrowsAsync<ArgumentNullException>(() => clientService.PostAsync<object>("url", null));
        }
    }
}
