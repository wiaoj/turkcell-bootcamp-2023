using Application.Services.AssemblyReference;
using Application.Services.Common;
using Application.Services.Extensions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Application;
public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediatR(configuration => {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        MappingExtensions.Mapper = services.BuildServiceProvider().GetRequiredService<IMapper>();

        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        return services.AddService<ISurveyService>()
                       .AddService<IAnswerService>()
                       .AddService<IAuthenticationService>()
                       .AddService<IDateTimeProvider>();
    }

    private static IServiceCollection AddService<TService>(this IServiceCollection services) {
        return services.Scan(scan => {
            scan.FromAssembliesOf(typeof(IServiceAssemblyReference))
                .AddClasses(classes => classes.AssignableTo<TService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
    }
}