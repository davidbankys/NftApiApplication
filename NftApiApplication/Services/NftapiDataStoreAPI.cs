using NftApiApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NftApiApplication.Services;
using System.Dynamic;

namespace EmployeeApplication.Services
{
    class NftapiDataStoreAPI : INftapiDataStore<Nftapi>
    {
        private static string API => "https://randomuser.me/api/";

        public async Task<IEnumerable<Nftapi>> GetEmployeesAsync(int count)
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}?results={count}");

            var employees = EmployeeBuilder(json);

            return nftapi;
        }
        private List<Nftapi> EmployeeBuilder(string json)
        {

            var response = JsonConvert.DeserializeObject<dynamic>(json);
            var users = response.results;

            var nftapis = new List<Nftapi>();

            foreach (var user in users)
            {
                var firstName = user.name.first.ToString();
                var lastName = user.name.last.ToString();
                var name = $"{firstName} {lastName}";
                var email = user.email.ToString();
                var image = user.picture.medium.ToString();

                employees.Add(new Nftapi(name, email, image));

            }

            return employees;
        }

        public static class UserBuilder
        {

        }
    }
}