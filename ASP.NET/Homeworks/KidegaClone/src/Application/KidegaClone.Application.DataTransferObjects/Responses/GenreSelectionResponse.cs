namespace KidegaClone.Application.DataTransferObjects.Responses;
public sealed record GenreSelectionResponse : IResponse {
    public required Guid Id { get; init; }
    public required String Name { get; init; }
}