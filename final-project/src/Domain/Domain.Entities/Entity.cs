using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;
public interface IEntity { }

public abstract class Entity : IEntity {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }

    protected Entity() {
        this.Id ??= $"{new BsonObjectId(ObjectId.GenerateNewId())}";
    }
}

public abstract class AggregateRoot : Entity {
    [BsonElement]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}