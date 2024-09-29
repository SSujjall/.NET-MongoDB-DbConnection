using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NetMongoDbTest.Models
{
    public class Customer
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Details> Detail { get; set; }
    }

    public class Details
    {
        public string? Phone { get; set; }
        public string? status { get; set; }
    }
}
