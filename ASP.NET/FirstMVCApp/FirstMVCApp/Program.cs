var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

var message = app.Configuration.GetSection("Message")["meet"];

//app.MapGet("/", () => message);

//.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
/*
 * Soda dolum tesisi
 * 1. Þiþeye etiket bas -> Middleware
 * 2. Sodayý þiþeye doldur -> Middleware
 * 3. Þiþenin kapaðýný kapat -> Middleware
 * 4. Þiþeyi kasaya yerleþtir -> Middleware
 */

//app.UseWelcomePage();
app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Run();