namespace KidegaClone.Application.DataTransferObjects.Responses;
public sealed record AuthorSelectionResponse : IResponse {
    public Guid Id { get; init; }
    public String FullName { get; init; }
}