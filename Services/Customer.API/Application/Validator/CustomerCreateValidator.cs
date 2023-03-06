using FluentValidation;
using CustomerAPI.Infrastructure.Persistence;

namespace CustomerAPI.Core.Application.Validator
{
    internal class CustomerCreateValidator : AbstractValidator<CustomerCreateDTO>
    {
        private readonly CustomerContext _dbContext;
        public CustomerCreateValidator(CustomerContext dbContext)
        {
            _dbContext = dbContext;
            //RuleFor(r => r.Title).NotNull();
            //RuleFor(r => r.Description).NotNull();
            //RuleFor(r => r.PartnerId).NotNull().WithMessage("Invalid Subscription.");

        }
    }
}
