using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities.Survey;
public class SurveyEntity : AggregateRoot {
    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string Title { get; private set; }

    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    [BsonIgnoreIfNull]
    public string? Description { get; private set; }

    [BsonElement]
    [BsonIgnoreIfDefault]
    public ICollection<QuestionEntity> Questions { get; private set; }

    public SurveyEntity(string title, string description) {
        this.Title = title;
        this.Description = description;
        this.Questions = new HashSet<QuestionEntity>();
    }

    public SurveyEntity SetQuestions(IEnumerable<QuestionEntity> questions) {
        this.Questions = questions.ToList();
        return this;
    }
}