using System.Net.Http.Headers;
using Newtonsoft.Json;
using StratzDotNet.Models;

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

    public async Task<List<GameVersion>> GetGameVersionAsync()
    {
        var response = await GetAsync("GameVersion");

        var content = await response.Content.ReadAsStringAsync();

        // parse the result
        var gameVersions = JsonConvert.DeserializeObject<List<GameVersion>>(content);

        return gameVersions;
    }

    public async Task<List<GameMode>> GetGameModesAsync()
    {
        var response = await GetAsync("GameMode");

        var content = await response.Content.ReadAsStringAsync();

        var gameModesDict = JsonConvert.DeserializeObject<Dictionary<string, GameMode>>(content);

        var gameModes = new List<GameMode>();

        foreach (var i in gameModesDict)
        {
            gameModes.Add(i.Value);
        }

        return gameModes;
    }

    public async Task<List<Hero>> GetHeroesAsync()
    {
        var response = await GetAsync("hero");

        var content = await response.Content.ReadAsStringAsync();

        var heroesDict = JsonConvert.DeserializeObject<Dictionary<string, Hero>>(content);

        var heroes = new List<Hero>();

        foreach (var i in heroesDict)
        {
            heroes.Add(i.Value);
        }

        return heroes;
    }

}
