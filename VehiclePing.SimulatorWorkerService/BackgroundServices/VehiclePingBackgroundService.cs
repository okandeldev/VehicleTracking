﻿using Core.Shared;
using Newtonsoft.Json;
using System.Text;

namespace VehiclePing.SimulatorWorkerService.BackgroundServices
{
    public class RequestVehiclePing
    {
        public string Id { get; set; }
        public string vin { get; set; }
    }

    public class PagedResponse11<T> where T : class
    {
        public List<T> list;
    }

    public class VehiclePingBackgroundService : BackgroundService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(60);
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<VehiclePingBackgroundService> _logger;

        public VehiclePingBackgroundService(HttpClient httpClient, ILogger<VehiclePingBackgroundService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        { 
            string VehicleAPI = _configuration.GetValue<string>("RemoteHosts:VehicleAPI");
            string TrackingAPI = _configuration.GetValue<string>("RemoteHosts:TrackingAPI");

            string VehicleListAPI = $"{VehicleAPI}/api/Vehicles?PageSize=50";
            string VehiclePingAPI = $"{TrackingAPI}/api/VehiclePing";

            using PeriodicTimer timer = new PeriodicTimer(_period);

            using var vehicleshttpResponse = await this._httpClient.GetAsync(VehicleListAPI, cancellationToken);
            _logger.LogInformation(vehicleshttpResponse.Content.ToString());

            var vehiclesStringContent = await vehicleshttpResponse.Content.ReadAsStringAsync(cancellationToken); 
            var vehicles = Newtonsoft.Json.JsonConvert.DeserializeObject<PagedResponse<RequestVehiclePing>>(vehiclesStringContent);

            while (
                !cancellationToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(cancellationToken))
            {

                try
                {
                    Random random = new Random();

                    int randomvValue = random.Next(0, vehicles.list.Count);
                    var vehicleId = vehicles.list[randomvValue].Id;
                    _logger.LogInformation("Vehicle Ping Started", vehicleId);
                    var vehiclePing = new { vehicleId = vehicleId, vehicleStatus = 1, message = "test-" + DateTime.Now.ToString() };
                    string contents = JsonConvert.SerializeObject(vehiclePing);
                    var content = new StringContent(contents, Encoding.UTF8, "application/json");

                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var res = await this._httpClient.PostAsync(VehiclePingAPI, content, cancellationToken);
                    _logger.LogInformation(res.ToString());


                }
                catch (Exception ex)
                {
                    _logger.LogInformation(
                        $"Failed to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
                }
            }
        }
    }

}
