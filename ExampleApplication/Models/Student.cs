using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ExampleApplication.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;


      
        public string Name { get; set; } = String.Empty;

        [BsonElement("isgraduated")]
        public bool Isgraduated { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }


        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("friend")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FriendId { get; set; } = String.Empty;

    }
}
