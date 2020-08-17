using GhnShipping.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GhnShipping.Infrastructure.Customers
{
    public interface IStoreService
    {
        public Task<IList<Store>> GetStores(string token);
    }
}
