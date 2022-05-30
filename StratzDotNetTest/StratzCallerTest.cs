using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StratzDotNet;
using StratzDotNet.Models;

namespace StratzDotNetTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestBaseUriAssignment()
    {
        using (var caller = new StratzCaller())
        {
            Assert.AreEqual("https://api.stratz.com/api/v1/", caller.BaseAddress.AbsoluteUri);
        }
    }

    [TestMethod]
    public void TestGetGameVersion()
    {
        using (var caller = new StratzCaller())
        {
            var gameVersionResponse = caller.GetGameVersionAsync().Result;

            var firstGameVersion = new GameVersion()
            {
                Id = 1,
                Name = "6.70",
                StartDate = new DateTime(2011, 1, 18)
            };

            Assert.AreEqual(152, gameVersionResponse.Count);
            Assert.AreEqual(firstGameVersion.Id, gameVersionResponse.Last().Id);
            Assert.AreEqual(firstGameVersion.Name, gameVersionResponse.Last().Name);
            Assert.AreEqual(firstGameVersion.StartDate, gameVersionResponse.Last().StartDate);
        }
    }

    [TestMethod]
    public void TestGetModesAsync()
    {
        using (var caller = new StratzCaller())
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
    public void TestGetHeroesAsync()
    {
        using (var caller = new StratzCaller())
        {
            var heroes = caller.GetHeroesAsync().Result;

            var heroJson = File.ReadAllText("Hero.json");

            var expectedHero = JsonConvert.DeserializeObject<Hero>(heroJson);
            var firstHero = heroes.First();

            // ids go up to 137, but only 123 heroes are returned
            Assert.AreEqual(123, heroes.Count);
            Assert.AreEqual(expectedHero.Id, firstHero.Id);
            Assert.AreEqual(expectedHero.ShortName, firstHero.ShortName);
            Assert.AreEqual(expectedHero.Abilities.Count, firstHero.Abilities.Count);
            Assert.AreEqual(expectedHero.Stat.StrengthBase, firstHero.Stat.StrengthBase);
        }
    }
}