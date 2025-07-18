using CatchUp2406.News.Application.Internal.CommandServices;
using CatchUp2406.News.Domain.Repositories;
using CatchUp2406.News.Domain.Services;
using CatchUp2406.News.Infrastructure;
using CatchUp2406.Shared.Domain.Repositories;
using CatchUp2406.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CatchUp2406.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUp2406.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);



// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());


// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    // Stop the application if the connection string is not set.
    throw new Exception("Database connection string is not set.");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });


// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// News Bounded Context Injection Configuration
builder.Services.AddScoped<IFavoriteSourceRepository, FavoriteSourceRepository>();
builder.Services.AddScoped<IFavoriteSourceCommandService, FavoriteSourceCommandService>();
builder.Services.AddScoped<IFavoriteSourceQueryService, FavoriteSourceQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
