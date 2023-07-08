using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities.Survey;
public class QuestionEntity : Entity {
    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    public string Text { get; private set; }

    [BsonElement]
    [BsonRepresentation(BsonType.String)]
    [BsonIgnoreIfDefault]
    public string Type { get; private set; }

    [BsonElement]
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsMultiSelect { get; private set; }

    [BsonElement]
    [BsonIgnoreIfDefault]
    public IEnumerable<OptionEntity> Options { get; private set; }

    public QuestionEntity(string text, bool isMultiSelect) : this(text, isMultiSelect, "normal") { }

    protected QuestionEntity(
        string text,
        bool isMultiSelect,
        string type) : this(text, isMultiSelect, type, new HashSet<OptionEntity>()) { }

    public QuestionEntity(
        string text,
        bool isMultiSelect,
        string type,
        IEnumerable<OptionEntity> options) {
        this.Text = text;
        this.IsMultiSelect = isMultiSelect;
        this.Type = type;
        this.Options = options;
    }

    protected void SetOptions(IEnumerable<OptionEntity> options) {
        this.Options = options.ToList();
    }
}