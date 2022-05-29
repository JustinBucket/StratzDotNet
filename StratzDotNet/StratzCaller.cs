using System.Net.Http.Headers;

namespace StratzDotNet;
public class StratzCaller : HttpClient
{
    public StratzCaller()
    {
        BaseAddress = new Uri("https://api.stratz.com/api/v1/");

        var apiKey = Helpers.GetApiKey().Result;
        DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);
    }

    public async Task<string> GetGameVersion()
    {
        var response = await GetAsync("GameVersion");

        var content = await response.Content.ReadAsStringAsync();

        return content;
    }

}
