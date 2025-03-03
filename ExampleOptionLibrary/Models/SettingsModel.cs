using ExampleOptionLibrary.Constants;
using ExampleOptionLibrary.Models.Settings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ExampleOptionLibrary.Models
{
    public class SettingsModel
    {
        [ConfigurationKeyName(ExampleConstants.DbSettingTitle)]
        public DbSettingsModel DbSettings { get; set; } = default!;
    }
}
