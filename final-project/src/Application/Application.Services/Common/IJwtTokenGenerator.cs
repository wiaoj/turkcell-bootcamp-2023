namespace Application.Services.Common;
public interface IJwtTokenGenerator {
    AuthenticationResponse GenerateToken(ApplicationUser user);
}