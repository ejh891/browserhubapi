using Microsoft.Extensions.Options;
using MongoDB.Driver;
using browserhubapi.Models;

namespace browserhubapi.Data {
    public class BrowserHubDbContext
    {
        private readonly IMongoDatabase _database = null;

        public BrowserHubDbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Bookmark> Bookmarks
        {
            get
            {
                return _database.GetCollection<Bookmark>("Bookmarks");
            }
        }
    }
}