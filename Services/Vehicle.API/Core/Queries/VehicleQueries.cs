using MediatR;
using VehicleAPI.Core.Models;
using X.PagedList;

namespace VehicleAPI.Core.Queries
{
    public record GetVehiclesQuery(VehiclesQueryParams queryParams) : IRequest<IPagedList<Vehicle>>;
    public record GetVehicleByIDQuery(Guid vehicleId) : IRequest<VehicleDTO>;

     
    #region Lookups
    public record GetVehicleStatusQuery() : IRequest<IReadOnlyList<VehicleStatus>>;
    #endregion
}
