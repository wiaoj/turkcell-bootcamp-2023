using CourseApp.Infrastructure.Repositories;
using CourseApp.Services;
using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CourseApp.Services.Mappings;

namespace CourseApp.API.Extensions;
public static class IoCExtensions {
    public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseRepository, EFCourseRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, EFCategoryRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(typeof(MapProfile));

        String connectionString = configuration.GetConnectionString("MsSQLConnectionString")!;

        services.AddDbContext<CourseDbContext>(option => {
            option.UseSqlServer(connectionString);
        });
        return services;
    }
}