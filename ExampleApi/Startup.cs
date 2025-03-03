using ExampleApi.Data;
using ExampleApi.Services;
using ExampleApi.Services.Interfaces;
using ExampleOptionLibrary.Helper;
using ExampleOptionLibrary.Services;
using ExampleOptionLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public static class Startup
{
    public static WebApplication Build()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddSingleton<ISettingConfigurationService , SettingConfigurationService>();

        var test = ConnectionHelper.GetConnectionStringFromBuilder(builder);

        builder.Services.AddDbContext<ExampleDbContext>(options =>
        {
            var connectionString = ConnectionHelper.GetConnectionStringFromBuilder(builder);

            var dbConnection = 
                options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString));
        });

        // Adding service to Service Collection for Dependency Injection
        builder.Services.AddTransient<IExampleCrudService, ExampleCrudService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        return builder.Build();
    }
}
