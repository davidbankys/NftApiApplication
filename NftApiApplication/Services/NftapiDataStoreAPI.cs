using NftApiApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NftApiApplication.Services;
using System.Dynamic;

namespace NftApiApplication.Services
{
    class NftapiDataStoreAPI : INftapiDataStore<Nftapi>
    {
        private static string API => "https://api.opensea.io/api/v1/assets?format=json";


        public async Task<IEnumerable<Nftapi>> GetNftapisAsync(int count)
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}?results={count}");

            var nftapi = NftapiAPIBuilder(json);

            return nftapi;
        }
        private List <Nftapi> NftapiAPIBuilder(string json)
        {

            var response = JsonConvert.DeserializeObject<dynamic>(json);
            var users = response.results;

            var nft_api = new List<Nftapi> ();

            foreach (var user in users)
            {
              
                var name = $"Name";
                var image_url = user.picture.medium.ToString();
                nft_api.Add(new Nftapi(name, image_url));

            }

            return nft_api;
        }

        public static class UserBuilder
        {

        }
    }
}