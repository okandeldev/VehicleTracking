using AutoMapper;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using TrackingAPI.Models.Request;
using TrackingAPI.Services;

namespace TrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePingController : ControllerBase
    {
        private readonly IVehicleHistoryStatusService _service;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventBus;

        public VehiclePingController(IMapper mapper, IVehicleHistoryStatusService service, EventBusRabbitMQProducer eventBus)
        {
            _service = service;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
         

        [HttpPost]
        public async Task<IActionResult> Ping(RequestVehiclePing request)
        {
            var eventMessage = _mapper.Map<VehiclePingEvent>(request);

            try
            {
                _eventBus.PublishVehiclePingEvent(EventBusConstants.VehiclePingQueue, eventMessage);
                await _service.CreateAsync(new RequestVehiclePing()
                {
                    VehicleId = request.VehicleId,
                    Message = request.Message,
                    VehicleStatus = request.VehicleStatus,
                });
            }
            catch (Exception)
            {
                throw;
            }

            return Accepted();
        }
    }
}
