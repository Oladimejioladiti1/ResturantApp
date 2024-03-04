using ResturantApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ResturantApp.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<ResturantAppContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ResturantAppContext>().AddDefaultTokenProviders();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<EmailService>();

//logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();


////////////////////////////////////////////////////////////////////////////////////////////////

//database operations when the program first starts
using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
{

    //Create Roles
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Manager", "Admin", "User" }; //Roles to be added

    foreach (var role in roles)
    {
        //Ensure the role does not exist to prevent duplicate entry
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

//database operations when the program first starts
using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
{
    //Create User
    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "manager@gmail.com";
    string password = "Password123,"; //Password must contain special character

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.Email = email;
        user.UserName = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRolesAsync(user, new[] { "Manager", "Admin", "User" });
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};
//
//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();
//
//app.Run();
//
//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}


