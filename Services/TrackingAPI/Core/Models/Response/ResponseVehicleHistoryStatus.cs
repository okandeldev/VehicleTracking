
using Core.Enum;

namespace TrackingAPI.Models.Response 
{
    public class ResponseVehicleHistoryStatus  
    {
        public string VehicleId { get; set; }
        public VehicleStatusEnum VehicleStatus { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
