using ExampleOptionLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleOptionLibrary.Helper
{
    /// <summary>
    /// Helper class for the database connection
    /// </summary>
    public static class ConnectionHelper
    {
        /// <summary>
        /// Gets the database conenction string based on its settings in the project (in appsettings.json or a KeyVault, etc.)
        /// </summary>
        /// <param name="builder"></param>
        /// <returns>Connection String</returns>
        /// <exception cref="Exception"></exception>
        public static string GetConnectionStringFromBuilder(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();

            using var scope = provider.CreateScope();

            try
            {
                var options = scope.ServiceProvider.GetService<ISettingConfigurationService>()?.GetDbSettings();

                if(options is null)
                {
                    throw new Exception("Exception handling should be implemented here");
                }

                return options.Value.DbSettings.DbConnectionString;
            }
            catch
            {
                throw new Exception("Here should be an exception handler");
            }
        }
    }
}
