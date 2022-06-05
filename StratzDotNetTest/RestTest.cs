using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using StratzDotNet;
using StratzDotNet.Models;
using StratzDotNet.Models.Rest;
using StratzDotNet.Rest;

namespace StratzDotNetTest;

// PUTTING THIS ON HOLD AS THE REST API IS NOT BEING MAINTAINED IN FAVOUR OF GRAPHQL API

[TestClass]
public class RestTest
{
    [TestMethod]
    public void TestBaseUriAssignment()
    {
        using (var caller = new StratzCaller("", true))
        {
            Assert.AreEqual("https://api.stratz.com/api/v1/", caller.BaseAddress.AbsoluteUri);
        }
    }

    // fails

    // [TestMethod]
    // public void TestGetGameVersion()
    // {
    //     using (var caller = new StratzCaller("", true))
    //     {
    //         var gameVersionResponse = caller.GetGameVersionAsync().Result;

    //         var firstGameVersion = new GameVersion()
    //         {
    //             Id = 1,
    //             Name = "6.70",
    //             StartDate = new DateTime(2011, 1, 18)
    //         };

    //         Assert.AreEqual(152, gameVersionResponse.Count);
    //         Assert.AreEqual(firstGameVersion.Id, gameVersionResponse.Last().Id);
    //         Assert.AreEqual(firstGameVersion.Name, gameVersionResponse.Last().Name);
    //         Assert.AreEqual(firstGameVersion.StartDate, gameVersionResponse.Last().StartDate);
    //     }
    // }

    [TestMethod]
    public void TestGetModes()
    {
        using (var caller = new StratzCaller("", true))
        {
            var gameModes = caller.GetGameModesAsync().Result;

            var expectedGameMode = new GameMode()
            {
                Id = 24,
                Name = "Mutation",
                LangKey = "gamemode.mutation"
            };

            var lastGameMode = gameModes.Last();

            Assert.AreEqual(25, gameModes.Count);
            Assert.AreEqual(expectedGameMode.Id, lastGameMode.Id);
            Assert.AreEqual(expectedGameMode.Name, lastGameMode.Name);
            Assert.AreEqual(expectedGameMode.LangKey, lastGameMode.LangKey);
        }
    }

    [TestMethod]
    public void TestGetHeroes()
    {
        using (var caller = new StratzCaller("", true))
        {
            var heroes = caller.GetHeroesAsync().Result;

            var heroJson = File.ReadAllText("Hero.json");

            var expectedHero = JsonConvert.DeserializeObject<Hero>(heroJson);
            var firstHero = heroes.First();

            // ids go up to 137, but only 123 heroes are returned
            Assert.AreEqual(123, heroes.Count);
            Assert.AreEqual(expectedHero.Id, firstHero.Id);
            Assert.AreEqual(expectedHero.ShortName, firstHero.ShortName);
            Assert.AreEqual(expectedHero.HeroAbilities.Count, firstHero.HeroAbilities.Count);
            Assert.AreEqual(expectedHero.Stat.StrengthBase, firstHero.Stat.StrengthBase);
        }
    }

    // [TestMethod]
    // public void TestGetAbilities()
    // {
    //     // sometimes language is not present in the read string
    //     using (var caller = new StratzCaller("", true))
    //     {
    //         var abilities = caller.GetAbilitiesAsync().Result;

    //         var abilityJson = File.ReadAllText("Ability.json");

    //         // put deserializer tracewriter here
            
    //         ITraceWriter traceWriter = new MemoryTraceWriter();

    //         var expectedAbility = JsonConvert.DeserializeObject<Ability>(abilityJson, new JsonSerializerSettings { TraceWriter = traceWriter, Converters = { new JavaScriptDateTimeConverter() } });
    //         Console.WriteLine(traceWriter);
    //         var targetAbility = abilities.FirstOrDefault(x => x.Id == 9999);

    //         Assert.AreEqual(expectedAbility.Name, targetAbility.Name);
    //         Assert.AreEqual(expectedAbility.AbilityLanguage.DisplayName, targetAbility.AbilityLanguage.DisplayName);
    //         Assert.AreEqual(expectedAbility.AbilityStat.Behavior, targetAbility.AbilityStat.Behavior);
    //         Assert.AreEqual(expectedAbility.IsTalent, targetAbility.IsTalent);
    //         Assert.AreEqual(expectedAbility.AbilityStat.MaxLevel, targetAbility.AbilityStat.MaxLevel);
    //         Assert.AreEqual(expectedAbility.AbilityStat.CastRanges[0], targetAbility.AbilityStat.CastRanges[0]);
    //     }

    // }

    [TestMethod]
    public void TestGetRegions()
    {
        using (var caller = new StratzCaller("", true))
        {
            var regions = caller.GetRegionsAsync().Result;

            var expectedRegion = new Region()
            {
                Id = 111,
                RegionId = 1
            };

            var firstRegion = regions.First();

            Assert.AreEqual(expectedRegion.Id, firstRegion.Id);
            Assert.AreEqual(expectedRegion.RegionId, firstRegion.RegionId);
        }
    }

    [TestMethod]
    public void TestGetRoles()
    {
        using (var caller = new StratzCaller("", true))
        {
            var roles = caller.GetRolesAsync().Result;

            var expectedRole = new Role()
            {
                Id = 0,
                Name = "Carry",
                LangKey = "roles.carry"
            };

            var firstRole = roles.First();

            Assert.AreEqual(expectedRole.Id, firstRole.Id);
            Assert.AreEqual(expectedRole.Name, firstRole.Name);
            Assert.AreEqual(expectedRole.LangKey, firstRole.LangKey);
        }
    }
}