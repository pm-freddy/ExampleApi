using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ExampleOptionLibrary.Services.Interfaces;
using ExampleOptionLibrary.Models;
using ExampleOptionLibrary.Constants;

namespace ExampleOptionLibrary.Services
{
    /// <summary>
    /// Service to bind the configurations in appsettings.json, key vault, etc. to an own IOptionsModel for dependency injection
    /// </summary>
    public class SettingConfigurationService : ISettingConfigurationService
    {
        private readonly IConfiguration _configuration;

        public SettingConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IOptions<SettingsModel> GetDbSettings()
        {
            var settings = new SettingsModel();
            _configuration.GetSection(ExampleConstants.ExampleSettingTitle).Bind(settings);

            return Options.Create(settings);
        }
    }
}
