using AutoMapper;
using TrackingAPI.Data.Repositories;
using TrackingAPI.Exceptions;
using TrackingAPI.Models.Entities;
using TrackingAPI.Models.Request;
using TrackingAPI.Models.Response;

namespace TrackingAPI.Services
{
    public class VehicleHistoryStatusService : IVehicleHistoryStatusService
    { 
        private readonly IVehiclePingHistoryRepository _vehicleHistoryStatusRepository; 
        private readonly IMapper _mapper;
        public VehicleHistoryStatusService(IVehiclePingHistoryRepository vehicleHistoryStatusRepository
            , IMapper mapper )
        {
            _vehicleHistoryStatusRepository = vehicleHistoryStatusRepository; 
            _mapper = mapper;
            
        }
        public async Task<Response<ResponseGetVehicleHistoryStatus>> GetByIdAsync(string id)
        {
            var vehicleHistoryStatus = await _vehicleHistoryStatusRepository.GetAsync(id);

            var responseGetVehicleHistoryStatus = _mapper.Map<ResponseGetVehicleHistoryStatus>(vehicleHistoryStatus);

            if(responseGetVehicleHistoryStatus == null)
            {
                throw new NotFoundException("VehicleHistoryStatus not found");
            }

            return Response<ResponseGetVehicleHistoryStatus>.Success(200, responseGetVehicleHistoryStatus);
        }
        public async Task<Response<IEnumerable<ResponseGetVehicleHistoryStatus>>> GetAllAsync()
        {
            var vehicleHistoryStatuss = await _vehicleHistoryStatusRepository.GetAllAsync();

            var responseGetVehicleHistoryStatuss = _mapper.Map<IEnumerable<ResponseGetVehicleHistoryStatus>>(vehicleHistoryStatuss);

            return Response<IEnumerable<ResponseGetVehicleHistoryStatus>>.Success(200, responseGetVehicleHistoryStatuss);
        }

        public async Task<Response<ResponseCreateVehicleHistoryStatus>> CreateAsync(RequestVehiclePing requestVehicleHistoryStatus)
        {
            var vehicleHistoryStatus = _mapper.Map<VehiclePing>(requestVehicleHistoryStatus);

            await _vehicleHistoryStatusRepository.CreateAsync(vehicleHistoryStatus);

            
            var responseCreateVehicleHistoryStatus = _mapper.Map<ResponseCreateVehicleHistoryStatus>(vehicleHistoryStatus);

            return Response<ResponseCreateVehicleHistoryStatus>.Success(200, responseCreateVehicleHistoryStatus);
        } 
    }
}
