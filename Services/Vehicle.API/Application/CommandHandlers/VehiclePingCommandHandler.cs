
using MediatR;
using VehicleAPI.Core.Commands;
using VehicleAPI.Core.Repositories;

namespace VehicleAPI.Application.CommandHandlers
{
    public class VehiclePingCommandHandler : IRequestHandler<VehiclePingCommand, Vehicle?>
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public VehiclePingCommandHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<Vehicle?> Handle(VehiclePingCommand request, CancellationToken cancellationToken)
        {
            Guid VehicleId = Guid.Empty;
            Guid.TryParse(request.ping.VehicleId, out VehicleId);
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var _vehiclesRepository = scopedServices.GetRequiredService<IVehiclesRepository>();

                var _vehicle = await _vehiclesRepository.GetByIdAsync(VehicleId);
                if (_vehicle != null)
                {
                    _vehicle.VehicleStatusId = (short)request.ping.VehicleStatus;
                    _vehicle.LastPing = DateTime.Now;
                    await _vehiclesRepository.UpdateAsync(_vehicle);
                }
                return _vehicle;
            }
        }
    }
}
