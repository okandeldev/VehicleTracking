using FluentValidation;

namespace CustomerAPI.Core.Application.Validator
{
    internal class CustomerUpdateValidator : AbstractValidator<CustomerUpdateDTO>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(r => r.FullName).NotNull();
        }
    }
}
