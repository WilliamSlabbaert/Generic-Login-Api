using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataLayer;
using DataLayer.Repo;
using DataLayer.Repo.Interfaces;
using Generic_Login_Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;


builder.Services.AddDbContext<MySqlDataContext>(options =>
    options.UseMySql(configuration["MY_LOCAL_DB"], ServerVersion.AutoDetect(configuration["MY_LOCAL_DB"]))
);


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "ValidIssuerHere",
        ValidAudience = "ValidIssuerHere",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["MY_KEY"])),
    };
});

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
