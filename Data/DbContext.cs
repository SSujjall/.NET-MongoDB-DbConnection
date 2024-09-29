using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NetMongoDbTest.Helper;
using NetMongoDbTest.Models;

namespace NetMongoDbTest.Data
{
    public class DbContext
    {
        public IMongoCollection<Customer>? _customerCollection;

        public DbContext(IOptions<MongoSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionUrl);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _customerCollection = mongoDatabase.GetCollection<Customer>("Customer");
        }
    }
}