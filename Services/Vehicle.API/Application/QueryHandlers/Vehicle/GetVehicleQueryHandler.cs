using MediatR;
using VehicleAPI.Core.Queries;
using VehicleAPI.Core.Repositories;
using X.PagedList;

namespace VehicleAPI.Application.QueryHandlers
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehiclesQuery, IPagedList<Vehicle>>
    {
        private readonly IVehiclesRepository _vehiclesRepository;

        public GetVehicleQueryHandler(IVehiclesRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        public async Task<IPagedList<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _vehiclesRepository.GetPagedListAsync(request.queryParams, cancellationToken); 
        }
    } 
}
