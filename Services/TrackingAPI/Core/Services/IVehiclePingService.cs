using TrackingAPI.Models.Request;
using TrackingAPI.Models.DTOs;

namespace TrackingAPI.Services
{
    public interface IVehiclePingService
    {
        Task<GetVehiclePingDto> GetByIdAsync(string id);
        Task<IEnumerable<GetVehiclePingDto>> GetAllAsync(); 
        Task<CreateVehiclePingDto> CreateAsync(RequestVehiclePing requestVehicleHistoryStatus);  
    }
}
