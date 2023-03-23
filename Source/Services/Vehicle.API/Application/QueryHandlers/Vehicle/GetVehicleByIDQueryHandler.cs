using AutoMapper;
using MediatR; 
using VehicleAPI.Core.Queries;
using VehicleAPI.Core.Repositories; 

namespace VehicleAPI.Application.QueryHandlers
{
    public class GetVehicleByIDQueryHandler : IRequestHandler<GetVehicleByIDQuery, VehicleDTO?>
    {
        private readonly IVehiclesRepository _vehiclesRepository;
        private readonly IMapper _mapper; 
        public GetVehicleByIDQueryHandler(IVehiclesRepository vehiclesRepository, IMapper mapper)
        {
            _vehiclesRepository = vehiclesRepository;
            _mapper = mapper;
        }
         
        public async Task<VehicleDTO?> Handle(GetVehicleByIDQuery request, CancellationToken cancellationToken)
        {
            var data =  await _vehiclesRepository.GetByIdAsync<Guid>(request.vehicleId); 
            if (data != null)
            {
                return _mapper.Map<VehicleDTO>(data);
            }
            return null;
        }
    }
}
