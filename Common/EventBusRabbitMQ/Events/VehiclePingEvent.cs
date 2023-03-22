using Core.Enum;

namespace EventBusRabbitMQ.Events
{
    public class VehiclePingEvent
    {   
        public string VehicleId { get; set; }
        public VehicleStatusEnum VehicleStatus { get; set; } = VehicleStatusEnum.Connected;
        public string Message { get; set; }

        public DateTime date { get; set; } = DateTime.UtcNow;
    }
}
