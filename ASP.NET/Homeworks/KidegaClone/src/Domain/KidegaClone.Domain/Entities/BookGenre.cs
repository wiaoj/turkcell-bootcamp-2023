namespace KidegaClone.Domain.Entities;
public sealed class BookGenre {
    public Guid BookId { get; set; }
    public IEnumerable<BookEntity> Books { get; set; }
    public Guid GenreId { get; set; }
    public IEnumerable<GenreEntity> Genres { get; set; }
}