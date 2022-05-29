using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratzDotNet
{
    public static class Helpers
    {
        public async static Task<string> GetApiKey()
        {
            var settings = await LoadSettings();

            return settings.ApiKey;
        }

        private async static Task<Settings> LoadSettings()
        {
            var fileText = await File.ReadAllTextAsync("Settings.json");

            var settings = JsonConvert.DeserializeObject<Settings>(fileText);

            return settings;
        }
    }

    class Settings
    {
        public string ApiKey { get; set; }
    }
}