using CourseApp.Infrastructure.Data;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Infrastructure.Repositories.Dapper;
using CourseApp.Services;
using CourseApp.Services.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, DapperCourseRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//Inversion of Control (IoC)

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession(option => {
    option.IdleTimeout = TimeSpan.FromMinutes(15);
}); // Session kullanmak isteniyorsa bu yazýlmalýdýr

String connectionString = builder.Configuration.GetConnectionString("MsSQLConnectionString")!;

builder.Services.AddDbContext<CourseDbContext>(option => {
    option.UseSqlServer(connectionString);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt => {
                    opt.LoginPath = "/Users/Login";
                    opt.AccessDeniedPath = "/Users/AccessDenied";
                    opt.ReturnUrlParameter = "returnUrl";
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using IServiceScope scope = app.Services.CreateScope();

IServiceProvider services = scope.ServiceProvider;

CourseDbContext context = services.GetRequiredService<CourseDbContext>();

context.Database.EnsureCreated();
DatabaseSeeding.SeedDatabase(context);



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); // Session middleware

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
