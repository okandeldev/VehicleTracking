using FluentValidation;

namespace VehicleAPI.Application.Validator
{
    internal class VehicleCreateValidator : AbstractValidator<VehicleCreateDTO>
    { 
        public VehicleCreateValidator()
        { 
            RuleFor(r => r.VIN).NotNull().NotEmpty();
            RuleFor(r => r.RegNr).NotNull();
        }
    }
}
