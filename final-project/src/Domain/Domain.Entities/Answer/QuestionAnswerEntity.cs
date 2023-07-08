using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities.Answer;
public class QuestionAnswerEntity : Entity {
    [BsonElement]
    [BsonRepresentation(BsonType.ObjectId)]
    public string QuestionId { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsMultiSelect { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string Type { get; set; } = "normal";

    [BsonElement]
    [BsonRepresentation(BsonType.Int32)]
    public int TotalVote { get; set; }
    public IEnumerable<OptionAnswerEntity> Options { get; set; }

    public QuestionAnswerEntity() { }

    public QuestionAnswerEntity(
        string questionId,
        IEnumerable<OptionAnswerEntity> options) : this(questionId, options, "normal") { }

    public QuestionAnswerEntity(string questionId,
                                IEnumerable<OptionAnswerEntity> options,
                                string type) {
        this.QuestionId = questionId;
        this.Options = options;
        this.Type = type;
    }

    public void AddVote() {
        this.TotalVote = ++this.TotalVote;
    }
}