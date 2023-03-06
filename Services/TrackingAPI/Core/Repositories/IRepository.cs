 namespace TrackingAPI.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(string id,T entity);
        Task DeleteAsync(string id);
    }
}
