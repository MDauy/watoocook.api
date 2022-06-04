using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBWrapper.Documents
{
    public abstract class BaseDocument
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Oid { get; set; }
    }
}
