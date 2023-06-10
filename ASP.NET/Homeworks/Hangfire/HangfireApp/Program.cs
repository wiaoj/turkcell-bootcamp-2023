using Hangfire;
using HangfireApp.HangfireAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string hangfireDatabaseConnectionString = builder.Configuration.GetConnectionString("HangfireConnectionString");

builder.Services.AddHangfire(configuration => {
    configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                 .UseSimpleAssemblyNameTypeSerializer()
                 .UseRecommendedSerializerSettings()
                 .UseSqlServerStorage(hangfireDatabaseConnectionString);
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/createjob", (string? message) => {
    BackgroundJob.Enqueue(() => Console.WriteLine($"{message} isimli görev bu {DateTime.UtcNow} tarihte iþlendi!"));
    return "Görev iletildi!";
})
.WithName("PostCreateJob");

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapHangfireDashboard("/myHangfireDashboard", new() {
        DashboardTitle = "Wiaoj Custom Hangfire Dashboard",
        Authorization = new[] {
            new HangfireDashboardAuthorizationFilter()
        }
    });
    ;
});

app.Run();