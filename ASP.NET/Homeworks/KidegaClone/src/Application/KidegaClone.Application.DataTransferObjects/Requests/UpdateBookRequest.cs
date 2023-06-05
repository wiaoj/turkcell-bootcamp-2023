namespace KidegaClone.Application.DataTransferObjects.Requests;
public sealed record UpdateBookRequest : IRequest {
    public Guid Id { get; init; }
    public String Title { get; init; }
    public String Barcode { get; init; }
    public Decimal Price { get; init; }
    public String ImageUrl { get; init; }
    public String? Description { get; init; }
    public String? CoverType { get; init; }
    public String? PaperType { get; init; }
    public Int16? PageCount { get; init; }

    public IEnumerable<Guid> Genres { get; init; }
    public DateTime? PublicationDate { get; init; }
    public String? Size { get; init; }
    public String? Weight { get; init; }
    public String? Dimensions { get; init; }

    public Guid? CategoryId { get; init; }

    public Guid AuthorId { get; init; }
}