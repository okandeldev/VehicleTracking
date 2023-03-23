using MediatR;
using CustomerAPI.Core.Queries; 
using X.PagedList;
using CustomerAPI.Core.Repositories;

namespace CustomerAPI.Core.Application.QueryHandlers
{
    internal class GetCustomerQueryHandler : IRequestHandler<GetCustomersQuery, IPagedList<Customer>>
    {
        private readonly ICustomersRepository _customersRepository;

        public GetCustomerQueryHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public Task<IPagedList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        { 
            return _customersRepository.GetPagedListAsync(request.queryParams, cancellationToken); 
        }
    }


}
