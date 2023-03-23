using Core.Repositories;
using VehicleAPI.Core.Models;
using X.PagedList;

namespace VehicleAPI.Core.Repositories
{
    public interface IVehiclesRepository : IRepository<Vehicle>
    {  
        Task<IPagedList<Vehicle>> GetPagedListAsync(VehiclesQueryParams  queryParams, CancellationToken cancellationToken);
   
    }
}
