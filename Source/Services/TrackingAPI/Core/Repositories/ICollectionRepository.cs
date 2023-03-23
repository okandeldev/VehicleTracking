namespace TrackingAPI.Core.Repositories
{
    public interface ICollectionRepository<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(string id,T entity);
        Task DeleteAsync(string id);
    }
}
