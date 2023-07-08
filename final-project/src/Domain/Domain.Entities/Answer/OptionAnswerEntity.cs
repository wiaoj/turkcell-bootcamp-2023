using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities.Answer;
public sealed class OptionAnswerEntity : Entity {
    [BsonElement]
    [BsonRepresentation(BsonType.ObjectId)]
    public string OptionId { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.Int32)]
    public int VoteCount { get; set; }

    public OptionAnswerEntity() { }

    public OptionAnswerEntity(String optionId) {
        this.OptionId = optionId;
    }

    public OptionAnswerEntity AddVote() {
        this.VoteCount++;
        return this;
    }
}