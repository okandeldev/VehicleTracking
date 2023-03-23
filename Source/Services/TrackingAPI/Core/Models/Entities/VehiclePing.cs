using Core.Enum;   

namespace TrackingAPI.Models.Entities
{
    public class VehiclePing : IEntity
    {
        public VehiclePing()
        { 
        }
        public string VehicleId { get; set; }
        public VehicleStatusEnum VehicleStatus { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
       
    }

}
