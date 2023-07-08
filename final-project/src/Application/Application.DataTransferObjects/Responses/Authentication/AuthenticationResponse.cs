namespace Application.DataTransferObjects.Responses.Authentication;
public sealed record AuthenticationResponse(string Token, DateTime Expiration) : IResponse;