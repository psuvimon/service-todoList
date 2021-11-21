using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReactASPCrud.Models
{
    public class TodoList
    {
        [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("todo")]
        public string Todo { get; set; }
    }
}