namespace KidegaClone.Application.DataTransferObjects.Responses;
public sealed record BookDisplayResponse : IResponse {
    public required Guid Id { get; init; }
    public required String Title { get; init; }
    public required Decimal Price { get; init; }
    public required String ImageUrl { get; init; }
    public required String AuthorFullName { get; init; }
}