using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using StratzDotNet.Models.Rest;

namespace StratzDotNet.Rest;
public class StratzCaller : HttpClient
{
    private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();

    public StratzCaller(string apiKey = "", bool enableJsonTrace = false)
    {
        BaseAddress = new Uri("https://api.stratz.com/api/v1/");
        
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            apiKey = Helpers.GetApiKey().Result;
        }

        if (enableJsonTrace)
        {
            ITraceWriter traceWriter = new MemoryTraceWriter();
            _serializerSettings.TraceWriter = traceWriter;
            _serializerSettings.Converters.Add(new JavaScriptDateTimeConverter());
        }

        DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);
    }

    private async Task<T> HandleCall<T>(string path)
    {
        var response = await GetAsync(path);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Request failed: {response.StatusCode}, {content}");
        }

        var returnObject = JsonConvert.DeserializeObject<T>(content, _serializerSettings);

        return returnObject;
    }

    public async Task<List<GameVersion>> GetGameVersionAsync()
    {
        var gameVersions = await HandleCall<List<GameVersion>>("gameVersion");

        return gameVersions;
    }

    public async Task<List<Region>> GetRegionsAsync()
    {
        var regions = await HandleCall<List<Region>>("cluster");

        return regions;
    }

    public async Task<List<Ability>> GetAbilitiesAsync()
    {
        var abilitiesDict = await HandleCall<Dictionary<string, Ability>>("ability");

        var abilities = new List<Ability>();

        foreach (var i in abilitiesDict)
        {
            abilities.Add(i.Value);
        }

        return abilities;
    }

    public async Task<List<GameMode>> GetGameModesAsync()
    {
        var gameModesDict = await HandleCall<Dictionary<string, GameMode>>("gameMode");

        var gameModes = new List<GameMode>();

        foreach (var i in gameModesDict)
        {
            gameModes.Add(i.Value);
        }

        return gameModes;
    }

    public async Task<List<Hero>> GetHeroesAsync()
    {
        var heroesDict = await HandleCall<Dictionary<string, Hero>>("hero");

        var heroes = new List<Hero>();

        foreach (var i in heroesDict)
        {
            heroes.Add(i.Value);
        }

        return heroes;
    }

    public async Task<List<Role>> GetRolesAsync()
    {
        var roles = await HandleCall<List<Role>>("hero/roles");

        return roles;
    }

}
