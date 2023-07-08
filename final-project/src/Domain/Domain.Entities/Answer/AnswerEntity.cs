using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Answer;
public sealed class AnswerEntity : AggregateRoot {
    [BsonElement]
    [BsonRepresentation(BsonType.ObjectId)]
    public string SurveyId { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.Int32)]
    public int TotalVote { get; private set; }

    [BsonElement]
    [BsonIgnoreIfDefault]
    public List<QuestionAnswerEntity> Questions { get; private set; }

    public AnswerEntity() { }


    public AnswerEntity(string surveyId) {
        this.SurveyId = surveyId;
        this.Questions = new();
    }

    public void AddQuestions(IEnumerable<QuestionAnswerEntity> questions) {
        this.Questions.AddRange(questions);
    }

    public void AddVote() {
        this.TotalVote = ++this.TotalVote;
    }
}