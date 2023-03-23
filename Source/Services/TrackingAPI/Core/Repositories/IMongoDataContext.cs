using MongoDB.Driver;

namespace TrackingAPI.Core.Repositories
{
    public interface IMongoDataContext
    {
        IMongoDatabase database { get; set; }
        MongoClient client { get; set; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
