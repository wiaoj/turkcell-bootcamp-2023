using Application.Application.Settings;
using Application.DataTransferObjects.Responses.Authentication;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Common;
internal sealed class JwtTokenGenerator : IJwtTokenGenerator {
    private readonly JwtSettings jwtSettings;
    private readonly IDateTimeProvider dateTimeProvider;

    public JwtTokenGenerator(
        IOptions<JwtSettings> jwtSettingsOptions,
        IDateTimeProvider dateTimeProvider) {
        this.jwtSettings = jwtSettingsOptions.Value;
        this.dateTimeProvider = dateTimeProvider;
    }

    public AuthenticationResponse GenerateToken(ApplicationUser user) {
        DateTime tokenExpiration = this.dateTimeProvider.UtcNow.AddMinutes(this.jwtSettings.ExpiryMinutes);

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        Claim[] claims = GetClaims(user);

        JwtSecurityToken jwtSecurityToken = CreateJwtSecurityToken(tokenExpiration, signingCredentials, claims);

        return new(
            Token: new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Expiration: tokenExpiration
        );
    }
    private Claim[] GetClaims(ApplicationUser user) {
        return new Claim[] {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.GivenName, user.Name),
            new(JwtRegisteredClaimNames.FamilyName, user.Surname),
            new(JwtRegisteredClaimNames.Name, $"{user.Name} {user.Surname}"),
            new(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}-{Guid.NewGuid()}"),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.AuthTime, this.dateTimeProvider.UtcNow.ToString())
        };
    }

    private JwtSecurityToken CreateJwtSecurityToken(
        DateTime tokenExpiration,
        SigningCredentials signingCredentials,
        Claim[] claims) {
        return new(
            issuer: this.jwtSettings.Issuer,
            audience: this.jwtSettings.Audience,
            claims: claims,
            notBefore: this.dateTimeProvider.UtcNow,
            expires: tokenExpiration,
            signingCredentials: signingCredentials);
    }
}