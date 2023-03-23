using MediatR; 
using VehicleAPI.Core.Queries;
using VehicleAPI.Core.Repositories;  

namespace VehicleAPI.Application.QueryHandlers
{
    public class GetVehicleStatusQueryHandler : IRequestHandler<GetVehicleStatusQuery, IReadOnlyList<VehicleStatus>>
    {
        private readonly IVehicleStatusRepository _vehicleStatusRepository;

        public GetVehicleStatusQueryHandler(IVehicleStatusRepository vehicleStatusRepository)
        {
            _vehicleStatusRepository = vehicleStatusRepository;
        }
        public async Task<IReadOnlyList<VehicleStatus>> Handle(GetVehicleStatusQuery request, CancellationToken cancellationToken)
        {
            return await _vehicleStatusRepository.GetAllAsync(cancellationToken); 
        }
    }
}
