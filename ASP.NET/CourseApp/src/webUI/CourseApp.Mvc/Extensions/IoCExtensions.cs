using CourseApp.Infrastructure.Repositories.Dapper;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Services;
using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Mvc.Extensions;
public static class IoCExtensions {
    public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseRepository, DapperCourseRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, EFCategoryRepository>();
        services.AddScoped<IUserService, UserService>();
        
        String connectionString = configuration.GetConnectionString("MsSQLConnectionString")!;

        services.AddDbContext<CourseDbContext>(option => {
            option.UseSqlServer(connectionString);
        });
        return services;
    }
}