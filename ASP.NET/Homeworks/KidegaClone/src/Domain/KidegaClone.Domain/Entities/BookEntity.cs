namespace KidegaClone.Domain.Entities;
public sealed class BookEntity : Entity {
    public String Title { get; set; }
    public String Barcode { get; set; }
    public Decimal Price { get; set; }
    public String ImageUrl { get; set; }
    public String? Description { get; set; }
    public String? CoverType { get; set; }
    public String? PaperType { get; set; }
    public Int16? PageCount { get; set; }

    public IEnumerable<GenreEntity> Genres { get; set; }
    public DateTime? PublicationDate { get; set; }
    public String? Size { get; set; }
    public String? Weight { get; set; }
    public String? Dimensions { get; set; }

    public Guid? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    public Guid AuthorId { get; set; }
    public AuthorEntity? Author { get; set; }
}