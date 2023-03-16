namespace homework3;
public abstract class Entity : IEntity<Guid> {
    public Guid Id { get; }
    public DateTime Created { get; }

    protected Entity() {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
    }
}