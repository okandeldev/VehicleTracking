
using Core.Enum;

namespace TrackingAPI.Models.DTOs
{
    public class VehiclePingDto  
    {
        public string VehicleId { get; set; }
        public VehicleStatusEnum VehicleStatus { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
