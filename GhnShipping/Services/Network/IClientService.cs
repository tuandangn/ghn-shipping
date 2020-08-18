using GhnShipping.Domain;
using System.Threading.Tasks;

namespace GhnShipping.Infrastructure.Network
{
    public interface IClientService
    {
        Task<ApiResponse<TResult>> GetAsync<TResult>(string url);

        Task<ApiResponse<TResult>> PostAsync<TResult>(string url, object payload);
    }
}
