

namespace VehicleAPI.Application.DTOs
{
    public class VehicleUpdateDTO
    {
        public Guid? VehicleId { get; set; }
        public string VIN { get; set; } = String.Empty;
        public string RegNr { get; set; } = String.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = String.Empty;
    }
}
