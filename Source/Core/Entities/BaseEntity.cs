namespace Core.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }

    public interface IAuditOnCreateEntity
    {
        string? CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public interface IAuditOnUpdateEntity
    {
        string? UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
    public interface IAuditOnDeleteEntity
    {
        DateTime? DeletedOn { get; set; }
    }
}
