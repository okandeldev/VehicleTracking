//using System.Collections;

//namespace TrackingAPI.BackgroundServices
//{
//    public class VehiclePingBackgroundService : BackgroundService
//    {
//        private readonly TimeSpan _period = TimeSpan.FromSeconds(60);
//        private readonly HttpClient _httpClient;
//        private readonly ILogger<VehiclePingBackgroundService> _logger;

//        public VehiclePingBackgroundService(HttpClient httpClient, ILogger<VehiclePingBackgroundService> logger)
//        {
//            _logger = logger;
//            _httpClient = httpClient;
//        }

//        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
//        {
//            //using PeriodicTimer timer = new PeriodicTimer(_period);
//            //while (
//            //    !cancellationToken.IsCancellationRequested &&
//            //    await timer.WaitForNextTickAsync(cancellationToken))
//            //{
//            //    try
//            //    { 
//            //        _logger.LogInformation(">>> Started");
//            //        var tt = new { vehicleId = "5c5057b0-90cf-4439-a30d-de6929c2faf3", vehicleStatus = 1, message = "test-" + DateTime.Now.ToString() };

//            //        await this._httpClient.PostAsJsonAsync(
//            //        "http://localhost:5082/api/VehiclePing", tt, cancellationToken).ContinueWith(res =>
//            //        {
//            //            _logger.LogInformation(res.ToString());

//            //        });
//            //    }
//            //    catch (Exception ex)
//            //    {
//            //        _logger.LogInformation(
//            //            $"Failed to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
//            //    }
//            //}
//        }
//    }

//}
