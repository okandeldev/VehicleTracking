using TrackingAPI.Core.Repositories;
using TrackingAPI.Models.Entities;

namespace TrackingAPI.Data.Repositories 
{
    public class VehiclePingHistoryRepository : BaseCollectionRepository<VehiclePing>, IVehiclePingRepository
    {
        public VehiclePingHistoryRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
