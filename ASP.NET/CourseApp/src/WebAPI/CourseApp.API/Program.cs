using CourseApp.API.Extensions;
using CourseApp.API.Filters;
using CourseApp.API.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(configure => {
    //configure.Filters.Add(typeof(NotImplementedAttribute));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Basic")
                .AddScheme<BasicOption, BasicHandler>("Basic", null);

builder.Services.AddInjections(builder.Configuration);

builder.Services.AddCors(option => {
    option.AddPolicy("allow", policy => { // her þeye izin ver
        policy.AllowAnyHeader() // header'daki bilgilere izin ver
              .AllowAnyMethod() // get - post - update ...
              .AllowAnyOrigin(); // http://www.turkcell.com.tr -> bir origindir
                                 // http://www.turkcell.com.tr/profile -> baþka bir origin deðildir
                                 // https://www.turkcell.com.tr -> baþka bir origindir
                                 // https://profile.turkcell.com.tr -> baþka bir origindir
                                 // https://www.turkcell.com.tr:8080 -> baþka bir origindir
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
