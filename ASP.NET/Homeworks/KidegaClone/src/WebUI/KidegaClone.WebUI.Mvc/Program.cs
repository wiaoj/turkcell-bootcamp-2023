using KidegaClone.Application;
using KidegaClone.Infrastructure.Persistence;
using KidegaClone.WebUI.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices()
                .AddPersistenceServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentityServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentity();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();