using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MongoDbCrudUsingAspNetCoreMVC.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        [BsonElement("PersonName")]
        public string PersonName { get; set; }

        [BsonElement("PersonAge")]
        public int PersonAge { get; set; }

        [BsonElement("HomeTown")]
        public string HomeTown { get; set; }
    }
}
