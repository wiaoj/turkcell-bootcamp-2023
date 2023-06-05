namespace KidegaClone.Domain.Entities;
public sealed class GenreEntity : Entity {
    public String Name { get; set; }

    public IEnumerable<BookEntity>? Books { get; set; }
}