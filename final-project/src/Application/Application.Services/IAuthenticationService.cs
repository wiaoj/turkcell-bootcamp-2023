using Application.DataTransferObjects.Requests.Authentication;
using Application.DataTransferObjects.Responses.Authentication;

namespace Application.Services;
public interface IAuthenticationService {
    Task<AuthenticationResponse> LoginUserAsync(LoginRequest loginRequest);
    Task<AuthenticationResponse> RegisterUserAsync(RegisterRequest registerRequest);
}