using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace browserhubapi.Models {
    public class Bookmark {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public string Id => ObjectId.ToString();
        public string Name { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set;}
    }
}