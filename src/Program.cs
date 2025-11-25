using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.Text;
using WowLogAnalyzer.Converters;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Services;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });
    
// JWT Key for Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? "Please Enter A Key");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();


var connectionString = builder.Configuration["Database:DefaultConnection"];
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.EnableDynamicJson();
var dataSource = dataSourceBuilder.Build(); 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dataSource).UseSnakeCaseNamingConvention()); 


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICombatLogService, CombatLogService>();
builder.Services.AddScoped<ICombatAnalyticsService, CombatAnalyticsService>();
builder.Services.AddScoped<IJwtSecurityService, JwtSecurityService>();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.Run();

internal class JwtTokenService
{
}