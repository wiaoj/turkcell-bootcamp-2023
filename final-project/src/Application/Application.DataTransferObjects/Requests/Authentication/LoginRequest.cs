namespace Application.DataTransferObjects.Requests.Authentication;
public sealed record LoginRequest(
    string Email,
    string Password) : IRequest;