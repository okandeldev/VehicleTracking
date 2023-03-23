using Core.Repositories; 
using VehicleAPI.Core.Models;
using VehicleAPI.Core.Repositories;
using VehicleAPI.Infrastructure.Persistence; 
using X.PagedList;

namespace VehicleAPI.Infrastructure.Repositories
{
    public class VehiclesRepository : Repository<Vehicle>, IVehiclesRepository
    {
        private readonly VehicleContext _dbContext;
        public VehiclesRepository(VehicleContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IPagedList<Vehicle>> GetPagedListAsync(VehiclesQueryParams queryParams, CancellationToken cancellationToken)
        {

            IQueryable<Vehicle> query = _dbContext.Set<Vehicle>();
            if (queryParams.status.HasValue)
            {
                query = query.Where(x => x.VehicleStatusId == queryParams.status.Value);
            }
            if (queryParams.customer?.Length > 0)
            {
                query = query.Where(x => queryParams.customer!.Any(c => c == x.CustomerId));
            }
            return await query.OrderByDescending(d => d.UpdatedOn).ToPagedListAsync(queryParams.PageNumber, queryParams.PageSize, cancellationToken);

        } 
    }
}
