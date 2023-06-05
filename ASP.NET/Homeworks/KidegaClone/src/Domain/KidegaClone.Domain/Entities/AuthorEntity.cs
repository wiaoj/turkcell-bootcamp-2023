namespace KidegaClone.Domain.Entities;
public sealed class AuthorEntity : Entity {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String? Biography { get; set; }
    public String? ImageUrl { get; set; }
    public String FullName { get; private set; }
    public IEnumerable<BookEntity>? Books { get; set; }
}