//using Microsoft.AspNetCore.Mvc;
//using TrackingAPI.Data.Repositories;
//using TrackingAPI.Models.Request;

//namespace TrackingAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VehiclePingHistoryController : ControllerBase
//    {
//        private readonly IVehiclePingHistoryRepository _service;

//        public VehiclePingHistoryController(IVehiclePingHistoryRepository service)
//        {
//            _service = service;
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> Get(string id)
//        {
//            return Ok(await _service.GetAsync(id));
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            return Ok(await _service.GetAllAsync());
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(RequestVehiclePingHistory request)
//        {
//            await _service.CreateAsync(new Models.Entities.IVehiclePingHistory()
//            {
//                 VehicleStatus = request.VehicleStatus,
//                  Message = request.Message,    
//                  VehicleId = request.VehicleId,
                   
//            });
//            return Ok();
//        }  

//    }
//}
