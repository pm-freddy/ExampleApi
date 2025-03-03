using ExampleOptionLibrary.Models;
using Microsoft.Extensions.Options;

namespace ExampleOptionLibrary.Services.Interfaces
{
    public interface ISettingConfigurationService
    {
        IOptions<SettingsModel> GetDbSettings();
    }
}