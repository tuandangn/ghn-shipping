using Moq;
using System.Net.Http;

namespace GhnShipping.Tests.Helpers
{
    public static class CreateHttpClientFactory
    {
        public static IHttpClientFactory Default => Mock.Of<IHttpClientFactory>();
    }
}
