using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CourseApp.API.Security;
public class BasicHandler : AuthenticationHandler<BasicOption> {
    public BasicHandler(
        IOptionsMonitor<BasicOption> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock) {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
        // 1. gelen request içinde authorization header'i var mı?
        if(this.Request.Headers.ContainsKey("Authorization") is false) {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // 2. authorization doğru formatta mı?
        if(AuthenticationHeaderValue.TryParse(this.Request.Headers["Authorization"], out AuthenticationHeaderValue? headerValue) is false) {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        if(headerValue is null) {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // 3. authorization Basic mi?
        if(headerValue.Scheme is not "Basic") {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        if(headerValue.Parameter is null) {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        Byte[] base64Bytes = Convert.FromBase64String(headerValue.Parameter);
        String decoded = Encoding.UTF8.GetString(base64Bytes);
        String username = decoded.Split(':')[0];
        String password = decoded.Split(':')[1];

        if(username is not "wiaoj" && password is not "123") {
            String failureMessage = "Kullanıcı adı veya şifre yanlış!";
            return Task.FromResult(AuthenticateResult.Fail(failureMessage));
        }

        Claim[] claims = new[] {
            new Claim(ClaimTypes.Name, username),
        };

        ClaimsIdentity identity = new(claims, this.Scheme.Name);
        ClaimsPrincipal claimsPrincipal = new(identity);
        AuthenticationTicket ticket = new(claimsPrincipal, this.Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}