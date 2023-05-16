var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

var message = app.Configuration.GetSection("Message")["meet"];

//app.MapGet("/", () => message);

//.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
/*
 * Soda dolum tesisi
 * 1. �i�eye etiket bas -> Middleware
 * 2. Soday� �i�eye doldur -> Middleware
 * 3. �i�enin kapa��n� kapat -> Middleware
 * 4. �i�eyi kasaya yerle�tir -> Middleware
 */

//app.UseWelcomePage();
app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Run();