using FluentValidation;

namespace VehicleAPI.Application.Validator
{
    internal class VehicleUpdateValidator : AbstractValidator<VehicleUpdateDTO>
    {
        public VehicleUpdateValidator()
        {
            RuleFor(r => r.VIN).NotNull().NotEmpty();
            RuleFor(r => r.RegNr).NotNull(); 
        }
    }
}
