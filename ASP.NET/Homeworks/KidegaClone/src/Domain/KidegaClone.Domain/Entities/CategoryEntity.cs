namespace KidegaClone.Domain.Entities;
public sealed class CategoryEntity : Entity {
    public String Name { get; set; }

    public IEnumerable<BookEntity>? Books { get; set; }
}