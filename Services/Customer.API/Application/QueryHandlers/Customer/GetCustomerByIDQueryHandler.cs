using AutoMapper;
using CustomerAPI.Core.Queries;
using CustomerAPI.Core.Repositories;
using MediatR;

namespace CustomerAPI.Core.Application.QueryHandlers
{
    internal class GetCustomerByIDQueryHandler : IRequestHandler<GetCustomerByIDQuery, CustomerDTO?>
    {

        private readonly IMapper _mapper;
        private readonly ICustomersRepository _customersRepository;

        public GetCustomerByIDQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customersRepository = customersRepository;
        }

        public async Task<CustomerDTO?> Handle(GetCustomerByIDQuery request, CancellationToken cancellationToken)
        {
            var data = await _customersRepository.GetByIdAsync(request.customerId);
            if (data != null)
            {
                return _mapper.Map<CustomerDTO>(data);
            }
            return null;
        }
    }
}
