using ExampleOptionLibrary.Constants;
using System.Text.Json.Serialization;

namespace ExampleOptionLibrary.Models.Settings
{
    public class DbSettingsModel
    {
        [JsonPropertyName(ExampleConstants.ExampleDbConnectionStringTitle)]
        public string DbConnectionString { get; set; } = default!;
    }
}
