using TrackingAPI.Models.Base;
using TrackingAPI.Models.Request;
using TrackingAPI.Models.Response;

namespace TrackingAPI.Services
{
    public interface IVehicleHistoryStatusService
    {
        Task<Response<ResponseGetVehicleHistoryStatus>> GetByIdAsync(string id);
        Task<Response<IEnumerable<ResponseGetVehicleHistoryStatus>>> GetAllAsync(); 
        Task<Response<ResponseCreateVehicleHistoryStatus>> CreateAsync(RequestVehiclePing requestVehicleHistoryStatus);  
    }
}
