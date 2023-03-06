using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace VehicleAPI.Test.Integration
{
    public class VehicleStatus
    {
        private HttpClient _httpClient;
        public VehicleStatus()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task Test_GetVehiclesQueryReuqest()
        { 
            var response = await _httpClient.GetAsync("http://localhost:5080/api/Vehicles");
            var result = await response.Content.ReadAsStringAsync();
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
