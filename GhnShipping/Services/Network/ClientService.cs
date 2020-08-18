using GhnShipping.Domain;
using GhnShipping.Services.Network;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GhnShipping.Infrastructure.Network
{
    public sealed class ClientService : IClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWorkContext _workContext;

        public ClientService(IHttpClientFactory httpClientFactory, IWorkContext workContext)
        {
            _httpClientFactory = httpClientFactory;
            _workContext = workContext;
        }

        public async Task<ApiResponse<TResult>> GetAsync<TResult>(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("Url is required", nameof(url));

            var httpClient = GetClient();
            var httpResponse = await httpClient.GetAsync(url).ConfigureAwait(false);
            var responseBody = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseResult = JsonConvert.DeserializeObject<ApiResponse<TResult>>(responseBody);

            return responseResult;
        }

        public async Task<ApiResponse<TResult>> PostAsync<TResult>(string url, object payload)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("Url is required", nameof(url));
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            var httpClient = GetClient();
            var requestContent = CreateJsonContent(payload);
            var httpResponse = await httpClient.PostAsync(url, requestContent).ConfigureAwait(false);
            var responseBody = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseResult = JsonConvert.DeserializeObject<ApiResponse<TResult>>(responseBody);

            return responseResult;
        }

        private HttpClient GetClient()
        {
            var useSandbox = _workContext.IsUseSandbox();

            if (useSandbox)
                return _httpClientFactory.CreateClient(ClientNames.DEVELOPMENT);
            return _httpClientFactory.CreateClient(ClientNames.PRODUCTION);
        }

        private HttpContent CreateJsonContent(object payload)
        {
            var serializedPayload = JsonConvert.SerializeObject(payload);
            var requestContent = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

            return requestContent;
        }
    }
}
