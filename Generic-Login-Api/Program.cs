using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataLayer;
using DataLayer.Repo;
using DataLayer.Repo.Interfaces;
using Generic_Login_Api.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("MySqlDatabase");

builder.Services.AddDbContext<MySqlDataContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
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
