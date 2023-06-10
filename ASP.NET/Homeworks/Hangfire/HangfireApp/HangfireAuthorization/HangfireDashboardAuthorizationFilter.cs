using Hangfire.Annotations;
using Hangfire.Dashboard;
using HangfireApp.Enums;
using System.Security.Claims;

namespace HangfireApp.HangfireAuthorization;

public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter {
    public Boolean Authorize([NotNull] DashboardContext context) {
        HttpContext httpContext = context.GetHttpContext();
        var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        return userRole == RoleEnum.HangfireOpenUser.ToString();
    }
}