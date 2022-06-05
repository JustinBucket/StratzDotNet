using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StratzDotNet.Models.GraphQl;

namespace StratzDotNetTest.TestModels
{
    public class Match
    {
        public bool DidRadiantWin { get; set; }
        public int DurationSeconds { get; set; }
        [Ignore]
        public int NumHumanPlayers { get; set; }
        [JsonProperty("GameMode")]
        public string DotaGameMode { get; set; }
    }
}