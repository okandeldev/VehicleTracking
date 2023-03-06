using MediatR;
using CustomerAPI.Core.Models;
using X.PagedList;

namespace CustomerAPI.Core.Queries
{
    public record GetCustomersQuery(CustomersQueryParams queryParams) : IRequest<IPagedList<Customer>>;
    public record GetCustomerByIDQuery(Guid customerId) : IRequest<CustomerDTO>;
     
}
