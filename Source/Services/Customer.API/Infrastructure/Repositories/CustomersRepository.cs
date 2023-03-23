using Core.Repositories; 
using CustomerAPI.Core.Models;
using CustomerAPI.Core.Repositories;
using CustomerAPI.Infrastructure.Persistence; 
using X.PagedList;

namespace CustomerAPI.Infrastructure.Repositories
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        private readonly CustomerContext _dbContext;
        public CustomersRepository(CustomerContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IPagedList<Customer>> GetPagedListAsync(CustomersQueryParams queryParams, CancellationToken cancellationToken)
        { 
            return await _dbContext.Set<Customer>().OrderByDescending(d => d.UpdatedOn).ToPagedListAsync(queryParams.PageNumber, queryParams.PageSize, cancellationToken);

        } 
    }
}
