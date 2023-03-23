using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace VehicleAPI.Test.Integration
{
    public class Vehicle
    {
        private HttpClient _httpClient;
        private readonly IConfigurationRoot _configuration;
        public Vehicle()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 
        }

        [Fact]
        public async Task Test_GetVehiclesQueryReuqest()
        { 
            string apiBaseUrl = _configuration.GetValue<string>("RemoteHosts:APIBaseUrl");
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/Vehicles");
            var result = await response.Content.ReadAsStringAsync();
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
