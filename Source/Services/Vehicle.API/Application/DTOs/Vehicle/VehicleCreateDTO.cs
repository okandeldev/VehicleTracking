namespace VehicleAPI.Application.DTOs
{
    public class VehicleCreateDTO
    {
        public string VIN { get; set; } = String.Empty;
        public string RegNr { get; set; } = String.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = String.Empty;

    }
}
