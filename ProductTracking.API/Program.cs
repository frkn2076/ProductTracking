using Microsoft.EntityFrameworkCore;
using ProductTracking.API.Data;
using ProductTracking.API.Extensions;
using ProductTracking.API.Services.BackgroundServices;
using ProductTracking.API.Services.Contracts;
using ProductTracking.API.Services.Implementations;
using ProductTracking.API.Utils;
using ProductTracking.API.Utils.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddOptionsWithValidateOnStart<ProductQueueSettings>()
    .Bind(builder.Configuration.GetSection(nameof(ProductQueueSettings)))
    .ValidateDataAnnotations();

builder.Services
    .AddOptionsWithValidateOnStart<ElasticSearchSettings>()
    .Bind(builder.Configuration.GetSection(nameof(ElasticSearchSettings)))
    .ValidateDataAnnotations();

builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresContext")));
builder.Services.AddSingleton<IQueueProcessor, QueueProcessor>();
builder.Services.AddSingleton<IQueueConfigurationManager, QueueConfigurationManager>();
builder.Services.AddSingleton<IQueuePublisher, QueuePublisher>();
builder.Services.AddSingleton<IElasticSearchService, ElasticSearchService>();
builder.Services.AddHostedService<QueueProcessingService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();

        var queuePublisher = scope.ServiceProvider.GetRequiredService<IQueuePublisher>();
        var seedProducts = dbContext.Products.ToList();
        Task.WhenAll(seedProducts.Select(x => queuePublisher.PublishMessageAsync(x.MapTo(OperationType.Insert)))).Wait();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
