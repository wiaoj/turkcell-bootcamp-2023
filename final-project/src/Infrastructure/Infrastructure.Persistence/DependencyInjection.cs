using Application.Application.Settings;
using Application.Repositories;
using Application.Services.Common;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Text;

namespace Infrastructure.Persistence;
public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration) {

        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));

        services.AddEntityFrameworkDbContext(configuration)
                .AddMongoClient()
                .AddRepositories()
                .AddAuthentication(configuration);

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }

    private static IServiceCollection AddMongoClient(this IServiceCollection services) {
        ConnectionStrings mongoDbSettings =
            services.BuildServiceProvider().GetRequiredService<IOptions<ConnectionStrings>>().Value;
        MongoClient mongoClient = new(mongoDbSettings.MongoDb.ConnectionURI);
        services.AddSingleton<IMongoClient>(mongoClient);
        return services;
    }

    private static IServiceCollection AddEntityFrameworkDbContext(this IServiceCollection services,
                                                                  IConfiguration configuration) {
        services.AddDbContext<SurveyDbContext>(option => {
            option.UseSqlServer(configuration.GetConnectionString("MsSQL"));
        });

        services.AddIdentityCore<ApplicationUser>(options => {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
        })
            .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<SurveyDbContext>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        DatabaseFacade database = serviceProvider.GetRequiredService<SurveyDbContext>().Database;
        database.EnsureCreated();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        return services.AddScoped<ISurveyRepository, SurveyRepository>()
                       .AddScoped<IAnswerRepository, AnswerRepository>();
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services,
                                                        IConfiguration configuration) {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SECTION_NAME));
        JwtSettings jwtSettings = 
            services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            };
        });

        return services;
    }
}