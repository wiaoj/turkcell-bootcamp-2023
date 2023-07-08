using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities.Answer;
public sealed class RatingQuestionAnswerEntity : QuestionAnswerEntity {
    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string MinimumValueDescription { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string MaximumValueDescription { get; set; }

    public RatingQuestionAnswerEntity() { }

    public RatingQuestionAnswerEntity(
        String questionId,
        string maximumValueDescription,
        string minimumValueDescription,
        IEnumerable<OptionAnswerEntity> options) : base(questionId, options, "rating") {
        this.MaximumValueDescription = maximumValueDescription;
        this.MinimumValueDescription = minimumValueDescription;
    }
}