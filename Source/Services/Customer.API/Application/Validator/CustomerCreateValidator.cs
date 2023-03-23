using FluentValidation;
using CustomerAPI.Infrastructure.Persistence;

namespace CustomerAPI.Core.Application.Validator
{
    internal class CustomerCreateValidator : AbstractValidator<CustomerCreateDTO>
    { 
        public CustomerCreateValidator( )
        { 
            RuleFor(r => r.FullName).NotNull(); 
        }
    }
}
