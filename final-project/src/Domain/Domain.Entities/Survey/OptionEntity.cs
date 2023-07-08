using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Survey;
public class OptionEntity : Entity {
    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string Text { get; private set; }

    public OptionEntity(string text) {
        this.Text = text;
    }
    
    public OptionEntity(int value) {
        this.Text = $"{value}";
    }
}