using Core.Repositories;
using CustomerAPI.Core.Models;
using X.PagedList;

namespace CustomerAPI.Core.Repositories
{
    public interface ICustomersRepository : IRepository<Customer>
    {  
        Task<IPagedList<Customer>> GetPagedListAsync(CustomersQueryParams  queryParams, CancellationToken cancellationToken);
   
    }
}
