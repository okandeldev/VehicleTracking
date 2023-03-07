using TrackingAPI.Models.Entities;

namespace TrackingAPI.Data.Repositories 
{
    public class VehiclePingHistoryRepository : BaseCollectionRepository<VehiclePing>, IVehiclePingHistoryRepository
    {
        public VehiclePingHistoryRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
