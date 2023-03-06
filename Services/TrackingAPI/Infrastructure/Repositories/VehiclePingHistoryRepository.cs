using TrackingAPI.Models.Entities;

namespace TrackingAPI.Data.Repositories 
{
    public class VehiclePingHistoryRepository : GenericRepository<VehiclePing>, IVehiclePingHistoryRepository
    {
        public VehiclePingHistoryRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
