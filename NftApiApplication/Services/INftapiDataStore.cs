using NftApiApplication.Models;
using NftApiApplication.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NftApiApplication.Services
{
    interface INftapiDataStore<T>
    {
        Task<IEnumerable<Nftapi>> GetNftapisAsync(int count);
    }
}