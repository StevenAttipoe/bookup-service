using System.ComponentModel;
using bookup_service;
using bookup_service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using bookup_service.Configurations;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Scan the assembly for repository classes and register them as services
var ServiceAssembly = typeof(IService).Assembly;
builder.Services.Scan(scan =>
    scan.FromAssemblies(ServiceAssembly)
        .AddClasses(classes => classes.AssignableTo<IService>())
        .AsImplementedInterfaces()
        .WithScopedLifetime()
);

// Add CORS to the container.
var ClientOrigin = "ClientPolicy";
builder.Services.AddCors(options =>
    options.AddPolicy(name: ClientOrigin, policy => {
            policy.WithOrigins("http://localhost:4200");
         })
);

//Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
    .EnableSensitiveDataLogging()
);

// Get the JWT secret key from configuration
builder.Configuration.AddJsonFile("environment.json", optional: false, reloadOnChange: true);
var jwtSecretKey = builder.Configuration.GetValue<string>("JwtSettings:SecretKey");

// Add JWT service with custom options
builder.Services.AddScoped<JwtService>(sp =>
{
    var issuer = "Book-Up-Service";
    var audience = "Client-App";

    return new JwtService(issuer, audience, jwtSecretKey!);
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "Book-Up-Service",
//            ValidAudience = "Client-App",
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SecretKey")))
//        };
//    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ClientOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();

