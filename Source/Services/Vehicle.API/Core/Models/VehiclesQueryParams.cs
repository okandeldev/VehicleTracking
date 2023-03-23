namespace VehicleAPI.Core.Models
{
    public record VehiclesQueryParams(Guid[]? customer = null, int? status = null, int PageSize = 10, int PageNumber = 1);
}
