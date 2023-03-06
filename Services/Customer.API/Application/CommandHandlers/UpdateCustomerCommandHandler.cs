
using CustomerAPI.Core.Commands;
using CustomerAPI.Core.Repositories;
using FluentValidation;
using MediatR;

namespace CustomerAPI.Core.Application.CommandHandlers
{
    internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer?>
    {
        private readonly ICustomersRepository _customersRepository;
        IValidator<CustomerUpdateDTO> _requestUpdateValidator;

        public UpdateCustomerCommandHandler(ICustomersRepository customersRepository, IValidator<CustomerUpdateDTO> requestUpdateValidator)
        {
            _customersRepository = customersRepository;
            _requestUpdateValidator = requestUpdateValidator;
        }

        public async Task<Customer?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _requestUpdateValidator.ValidateAsync(request.Customer);
            if (!validationResult.IsValid)
            {
                return null;
            }
            var _customer = await _customersRepository.GetByIdAsync(request.Customer.CustomerId);
            if (_customer != null)
            {
                _customer.FullName = request.Customer.FullName;
                _customer.Address = request.Customer.Address;
                await _customersRepository.UpdateAsync(_customer);
                return _customer;
            }
            return null;
        }
    }
}
