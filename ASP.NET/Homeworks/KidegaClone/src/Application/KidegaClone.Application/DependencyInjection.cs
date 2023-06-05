using AutoMapper;
using KidegaClone.Application.BusinessRules;
using KidegaClone.Application.Extensions;
using KidegaClone.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KidegaClone.Application;
public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        MappingExtensions.Mapper = services.BuildServiceProvider().GetRequiredService<IMapper>();

        return services.addBusinessRules()
                       .addEntityServices();
    }

    private static IServiceCollection addEntityServices(this IServiceCollection services) {
        return services.AddScoped<IBookService, BookService>()
                        .AddScoped<IGenreService, GenreService>()
                        .AddScoped<IAuthorService, AuthorService>()
                        .AddScoped<IUserService, UserService>();
    }

    private static IServiceCollection addBusinessRules(this IServiceCollection services) {
        return services.AddScoped<IBookBusinessRules, BookBusinessRules>()
                       .AddScoped<IUserBusinessRules, UserBusinessRules>();
    }
}