using DependencyInjectionLifeTime.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISingletonGuid, SingletonGuid>();
// Uygulama boyunca ayný nesne kullanýlýr

builder.Services.AddTransient<ITransientGuid, TransientGuid>();
// Ýhtiyaç duyulunca üretilip yok ediliyor

builder.Services.AddScoped<IScopedGuid, ScopedGuid>();
// Scope {} boyunca ayný nesne kullanýlabiliniyor

builder.Services.AddTransient<GuidService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
