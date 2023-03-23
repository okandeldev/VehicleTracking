
using CustomerAPI.Core.Commands;
using CustomerAPI.Core.Repositories;
using FluentValidation;
using MediatR;

namespace CustomerAPI.Core.Application.CommandHandlers
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer?>
    {
        private readonly ICustomersRepository _customersRepository;
        IValidator<CustomerCreateDTO> _requestCreateValidator;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository, IValidator<CustomerCreateDTO> requestCreateValidator)
        {
            _customersRepository = customersRepository;
            _requestCreateValidator = requestCreateValidator;
        }

        public async Task<Customer?> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _requestCreateValidator.ValidateAsync(request.Customer);
            if (!validationResult.IsValid)
            {
                return null;
            }
            var _customer = new Customer()
            {
                Id = Guid.NewGuid(),
                FullName = request.Customer.FullName,
                Address = request.Customer.Address,
            };
            await _customersRepository.AddAsync(_customer);

            return _customer;
        }
    }
}
