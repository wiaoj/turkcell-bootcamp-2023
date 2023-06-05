namespace KidegaClone.Application.DataTransferObjects.Requests;

public sealed record DeleteBookRequest : IRequest {
    public Guid Id { get; init; }
}