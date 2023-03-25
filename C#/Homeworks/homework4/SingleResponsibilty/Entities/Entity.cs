namespace SingleResponsibilty.Entities;
public abstract class Entity {
    public Guid Id { get; private set; }
    public DateTime Created { get; private set; }

    public Entity() {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
    }
}