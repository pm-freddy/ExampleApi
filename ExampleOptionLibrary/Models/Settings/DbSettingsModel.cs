using ExampleOptionLibrary.Constants;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace ExampleOptionLibrary.Models.Settings
{
    public class DbSettingsModel
    {
        [ConfigurationKeyName(ExampleConstants.ExampleDbConnectionStringTitle)]
        public string DbConnectionString { get; set; } = default!;
    }
}
