using Core.DataSeed;

namespace CustomerAPI.Infrastructure.Persistence
{
    public static class CustomerSeed
    {
        public static Customer[] Customers =  CustomersSeed.Customers.Select(c => new Customer()
            {
                Id = c.CustomerId,
                FullName = c.CustomerName,
                Address = c.Address,
            }).ToArray(); 
    }
}
