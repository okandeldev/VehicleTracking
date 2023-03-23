using AutoMapper; 
using TrackingAPI.Models.Entities;
using TrackingAPI.Models.Request;
using TrackingAPI.Models.DTOs; 
using TrackingAPI.Core.Repositories;

namespace TrackingAPI.Services
{
    public class VehiclePingService : IVehiclePingService
    { 
        private readonly IVehiclePingRepository _vehiclePingRepository; 
        private readonly IMapper _mapper;
        public VehiclePingService(IVehiclePingRepository vehicleHistoryStatusRepository
            , IMapper mapper )
        {
            _vehiclePingRepository = vehicleHistoryStatusRepository; 
            _mapper = mapper; 
        }
        public async Task<GetVehiclePingDto> GetByIdAsync(string id)
        {
            var vehiclePing = await _vehiclePingRepository.GetAsync(id); 
            return vehiclePing != null ? _mapper.Map<GetVehiclePingDto>(vehiclePing) : null;
        }
        public async Task<IEnumerable<GetVehiclePingDto>> GetAllAsync()
        {
            var vehiclePingList = await _vehiclePingRepository.GetAllAsync();  
            return _mapper.Map<IEnumerable<GetVehiclePingDto>>(vehiclePingList);
        }

        public async Task<CreateVehiclePingDto> CreateAsync(RequestVehiclePing requestVehicleHistoryStatus)
        {
            var vehiclePing = _mapper.Map<VehiclePing>(requestVehicleHistoryStatus);

            await _vehiclePingRepository.CreateAsync(vehiclePing); 

            return _mapper.Map<CreateVehiclePingDto>(vehiclePing);
        } 
    }
}
