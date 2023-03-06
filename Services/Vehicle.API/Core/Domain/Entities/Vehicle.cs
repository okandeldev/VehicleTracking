using Core.Entities;
using Core.Enum;

namespace VehicleAPI.Core.Domain.Entities
{
    public class Vehicle : BaseEntity<Guid>, IAuditOnCreateEntity, IAuditOnUpdateEntity, IAuditOnDeleteEntity
    {
        public string VIN { get; set; } = String.Empty;
        public string RegNr { get; set; } = String.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = String.Empty;
        public short VehicleStatusId { get; set; } = (short)VehicleStatusEnum.Disconnected;
        public VehicleStatus VehicleStatus { get; set; } 
        public DateTime? LastPing { get; set; }

        #region Auditing
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } 
        public DateTime? DeletedOn { get; set; }
        #endregion
    }
}
