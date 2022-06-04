using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratzDotNet.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DrawMatchPage { get; set; }
        public bool IsTalent { get; set; }
        [JsonProperty("language")]
        public AbilityLanguage AbilityLanguage { get; set; }
        [JsonProperty("stat")]
        public AbilityStat AbilityStat { get; set; }
    }
}