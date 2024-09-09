using JsonApiDotNetCore.Configuration;
using jsonapisample.Data;
using jsonapisample.Models;
using jsonapisample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString(nameof(AppDbContext));
    options.UseSqlServer(connectionString, builderOptions => builderOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});

builder.Services.AddScoped<LoginService>();

int apiVersion = builder.Configuration.GetValue<int>("ApiVersion");
builder.Services.AddJsonApi<AppDbContext>(options => options.Namespace = $"api/v{apiVersion}");


WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseJsonApi();

app.MapControllers();

await app.Services.CreateDatabaseAsync();

app.Run();

public static class DatabaseSeedingExtensions
{
    public static async Task CreateDatabaseAsync(this IServiceProvider serviceProvider)
    {
        await using AsyncServiceScope scope = serviceProvider.CreateAsyncScope();

        AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        IEnumerable<string> migrations = await dbContext.Database.GetPendingMigrationsAsync();
        if (migrations.Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}