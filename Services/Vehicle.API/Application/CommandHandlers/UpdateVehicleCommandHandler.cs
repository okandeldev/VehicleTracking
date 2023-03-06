
using FluentValidation;
using MediatR;
using VehicleAPI.Core.Commands;
using VehicleAPI.Core.Repositories;

namespace VehicleAPI.Application.CommandHandlers
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Vehicle?>
    {
        private readonly IVehiclesRepository _vehiclesRepository;
        IValidator<VehicleUpdateDTO> _requestUpdateValidator;
        public UpdateVehicleCommandHandler(IVehiclesRepository vehiclesRepository, IValidator<VehicleUpdateDTO> requestUpdateValidator)
        {
            _vehiclesRepository = vehiclesRepository;
            _requestUpdateValidator = requestUpdateValidator;
        }

        public async Task<Vehicle?> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _requestUpdateValidator.ValidateAsync(request.Vehicle);
            if (!validationResult.IsValid)
            {
                return null;
            }
            var _vehicle = await _vehiclesRepository.GetByIdAsync(request.Vehicle.VehicleId);
            if (_vehicle != null)
            {
                _vehicle.VIN = request.Vehicle.VIN;
                _vehicle.RegNr = request.Vehicle.RegNr;
                _vehicle.CustomerId = request.Vehicle.CustomerId;
                _vehicle.CustomerName = request.Vehicle.CustomerName;
                await _vehiclesRepository.UpdateAsync(_vehicle);
                return _vehicle;
            }
            return null;
        }
    }
}
