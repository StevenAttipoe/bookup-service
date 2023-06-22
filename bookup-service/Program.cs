using bookup_service;
using bookup_service.Interfaces;
using bookup_service.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Scan the assembly for repository classes and register them as services
var repositoryAssembly = typeof(IRepository).Assembly;
builder.Services.Scan(scan =>
    scan.FromAssemblies(repositoryAssembly)
        .AddClasses(classes => classes.AssignableTo<IRepository>())
        .AsImplementedInterfaces()
        .WithScopedLifetime()
);

//Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
    .EnableSensitiveDataLogging()
);

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

app.UseAuthorization();

app.MapControllers();

app.Run();

