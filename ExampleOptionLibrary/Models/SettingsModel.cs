using ExampleOptionLibrary.Constants;
using ExampleOptionLibrary.Models.Settings;
using Newtonsoft.Json;

namespace ExampleOptionLibrary.Models
{
    public class SettingsModel
    {
        [JsonProperty(ExampleConstants.DbSettingTitle)]
        public DbSettingsModel DbSettings { get; set; } = default!;
    }
}
