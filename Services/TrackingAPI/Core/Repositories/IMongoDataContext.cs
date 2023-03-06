using MongoDB.Driver;

namespace TrackingAPI.Data
{
    public interface IMongoDataContext
    {
        IMongoDatabase database { get; set; }
        MongoClient client { get; set; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
