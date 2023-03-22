
using Core.Enum;

namespace VehicleAPI.Application.DTOs
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }
        public string VIN { get; set; } = String.Empty;
        public string RegNr { get; set; } = String.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = String.Empty;
        public short VehicleStatusId { get; set; } = (short)VehicleStatusEnum.Disconnected;
        public VehicleStatus VehicleStatus { get; set; }
        public DateTimeOffset? LastPing { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
