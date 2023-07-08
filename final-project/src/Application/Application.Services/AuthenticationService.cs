using Application.Services.Common;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;
internal class AuthenticationService : IAuthenticationService {
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator) {
        this.userManager = userManager;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResponse> LoginUserAsync(LoginRequest loginRequest) {
        ApplicationUser user = await this.userManager.FindByEmailAsync(loginRequest.Email)
            ?? throw new Exception("Email veya Şifre yanlış!");

        Boolean isPasswordCorrect =
            await this.userManager.CheckPasswordAsync(user, loginRequest.Password);

        if(isPasswordCorrect is false)
            throw new Exception("Email veya Şifre yanlış!");

        return this.jwtTokenGenerator.GenerateToken(user);
    }

    public async Task<AuthenticationResponse> RegisterUserAsync(RegisterRequest registerRequest) {
        ApplicationUser user = registerRequest.MapTo<ApplicationUser>();
        user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, registerRequest.Password);

        IdentityResult identityResult =
            await this.userManager.CreateAsync(user);


        if(identityResult.Errors.Any()) {
            throw new Exception("Kayıt işlemi sırasında bir hata oluştu");
        }

        return this.jwtTokenGenerator.GenerateToken(user);
    }
}
