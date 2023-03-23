
using FluentValidation;
using MediatR;
using VehicleAPI.Core.Commands;
using VehicleAPI.Core.Repositories;

namespace VehicleAPI.Application.CommandHandlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Vehicle?>
    {
        private readonly IVehiclesRepository _vehiclesRepository;
        IValidator<VehicleCreateDTO> _requestCreateValidator;
        public CreateVehicleCommandHandler(IVehiclesRepository vehiclesRepository, IValidator<VehicleCreateDTO>  requestCreateValidator)
        {
            _vehiclesRepository = vehiclesRepository;
            _requestCreateValidator = requestCreateValidator;
        }

        public async Task<Vehicle?> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _requestCreateValidator.ValidateAsync(request.Vehicle);
            if (!validationResult.IsValid)
            {
                return null;
            }
            var _Vehicle = new Vehicle()
            {
                Id = Guid.NewGuid(),
                VIN = request.Vehicle.VIN,
                RegNr = request.Vehicle.RegNr,
                CustomerId = request.Vehicle.CustomerId,
                CustomerName = request.Vehicle.CustomerName,
            };
            await _vehiclesRepository.AddAsync(_Vehicle);
            return _Vehicle;
        }
    }
}
