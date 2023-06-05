namespace KidegaClone.Application.DataTransferObjects.Responses;
public sealed record BookDetailResponse : IResponse {
    public required Guid Id { get; init; }
    public required String Title { get; init; }
    public required Decimal Price { get; init; }
    public required String Barcode { get; init; }
    public String? Description { get; init; }
    public String? ImageUrl { get; init; }
    public String? CoverType { get; set; }
    public String? PaperType { get; set; }
    public Int16? PageCount { get; set; }

    public DateTime? PublicationDate { get; init; }
    public String? Size { get; init; }
    public String? Weight { get; init; }
    public String? Dimensions { get; init; }
    public IEnumerable<BookDetailGenre>? Genres { get; init; }
    public required BookDetailAuthor Author { get; init; }
}

public record BookDetailAuthor {
    public required Guid Id { get; init; }
    public required String FullName { get; init; }
    public String? Biography { get; init; }
    public String? ImageUrl { get; init; }
}

public record BookDetailGenre {
    public required String Name { get; init; }
}