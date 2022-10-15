using MongoDB.Bson.Serialization.Attributes;

namespace ExampleApplication.Models
{
    [BsonIgnoreExtraElements]
    public class StudentBase
    {
        public string[]? Courses { get; set; }
    }
}