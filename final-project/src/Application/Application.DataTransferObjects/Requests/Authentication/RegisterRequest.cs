namespace Application.DataTransferObjects.Requests.Authentication;
public sealed record RegisterRequest(
    string Name,
    string Surname,
    string Username,
    string Email,
    string Password) : IRequest;