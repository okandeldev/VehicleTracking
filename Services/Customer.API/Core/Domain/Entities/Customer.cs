using Core.Entities;

namespace CustomerAPI.Core.Domain.Entities
{
    public class Customer : BaseEntity<Guid>, IAuditOnCreateEntity, IAuditOnUpdateEntity, IAuditOnDeleteEntity
    {
        public string FullName { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;

        #region Auditing
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
        #endregion
    }
}
