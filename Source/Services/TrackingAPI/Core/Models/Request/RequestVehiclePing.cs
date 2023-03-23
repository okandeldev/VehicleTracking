using Core.Enum;

namespace TrackingAPI.Models.Request 
{
    public class RequestVehiclePing
    {
        public string VehicleId { get; set; }
        public VehicleStatusEnum VehicleStatus { get; set; } = VehicleStatusEnum.Connected;
        public string Message { get; set; }  
    }
}
