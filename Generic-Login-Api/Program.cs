using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataLayer;
using DataLayer.Repo;
using DataLayer.Repo.Interfaces;
using Generic_Login_Api.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cString = "Server=localhost;port=3306;Database=generic-authenticator;Uid=root;Pwd=coolmen15;";
builder.Services.AddDbContext<MySqlDataContext>(options =>
    options.UseMySql(cString, ServerVersion.AutoDetect(cString))
);

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ResponseMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
