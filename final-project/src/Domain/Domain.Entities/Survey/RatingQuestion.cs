using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities.Survey;
public sealed class RatingQuestionEntity : QuestionEntity {
    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string MinimumValueDescription { get; private set; }

    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string MaximumValueDescription { get; private set; }

    public RatingQuestionEntity(
        string text,
        string minimumValueDescription,
        string maximumValueDescription) : base(text, false, "rating") {
        SetOptions();
        this.MinimumValueDescription = minimumValueDescription;
        this.MaximumValueDescription = maximumValueDescription;
    }

    void SetOptions() {
        IEnumerable<OptionEntity> options =
            Enumerable.Range(1, 10).Select(x => new OptionEntity(x));
        base.SetOptions(options);
    }
}