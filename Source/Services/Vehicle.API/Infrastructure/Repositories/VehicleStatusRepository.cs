using Core.Repositories;
using VehicleAPI.Core.Repositories;
using VehicleAPI.Infrastructure.Persistence; 

namespace VehicleAPI.Infrastructure.Repositories
{
    public class VehicleStatusRepository : Repository<VehicleStatus>, IVehicleStatusRepository
    { 
        public VehicleStatusRepository(VehicleContext dbContext) : base(dbContext)
        { 
        }
    }
}
