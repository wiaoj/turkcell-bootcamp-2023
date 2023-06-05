using Microsoft.AspNetCore.Authentication.Cookies;

namespace KidegaClone.WebUI.Mvc.Extensions;
public static class IdentityExtensions {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services) {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt => {
                    opt.LoginPath = "/Users/Login";
                    opt.AccessDeniedPath = "/Users/AccessDenied";
                    opt.ReturnUrlParameter = "returnUrl";
                });
        services.AddAuthorization(options => {
            options.AddPolicy("Admin",
                authBuilder => {
                    authBuilder.RequireRole("Admin");
                });
        });
        return services;
    }

    public static IApplicationBuilder UseIdentity(this IApplicationBuilder applicationBuilder) {
        return applicationBuilder.UseAuthentication()
                                 .UseAuthorization();
    }
}