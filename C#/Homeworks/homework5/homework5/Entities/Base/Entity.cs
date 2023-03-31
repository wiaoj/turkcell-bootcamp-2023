namespace homework5.Entities.Base;
public abstract class Entity {
    public Guid Id { get; }
    public DateTime CreatedDate { get; }

    public Entity() {
        this.Id = Guid.NewGuid();
        this.CreatedDate = DateTime.UtcNow;
    }

    public String ShortId => this.Id.ToString()[..8];
}