using KidegaClone.Application.Common;
using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;
using KidegaClone.Infrastructure.Persistence.Common;
using KidegaClone.Infrastructure.Persistence.Context;
using KidegaClone.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KidegaClone.Infrastructure.Persistence;
public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration) {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddDbContext<KidegaCloneDbContext>(option => {
            option.UseSqlServer(configuration.GetConnectionString("MssqlConnectionString"));
        });

        services.AddIdentityCore<UserEntity>(options => {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;

            options.User.RequireUniqueEmail = true;

        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<KidegaCloneDbContext>();

        services.AddRepositories();

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        seedDatabase(serviceProvider);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        return services.AddScoped<IBookRepository, BookRepository>()
                       .AddScoped<IGenreRepository, GenreRepository>()
                       .AddScoped<IAuthorRepository, AuthorRepository>();
    }

    private static void seedDatabase(ServiceProvider serviceProvider) {
        DatabaseFacade database = serviceProvider.GetRequiredService<KidegaCloneDbContext>().Database;
        database.EnsureDeleted();
        database.EnsureCreated();

        UserManager<UserEntity> userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        DataSeeder.SeedData(userManager, roleManager);
    }
}