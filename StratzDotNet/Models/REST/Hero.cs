using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratzDotNet.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        [JsonProperty("abilities")]
        public List<HeroAbility> HeroAbilities { get; set; }
        [JsonProperty("roles")]
        public List<HeroRole> HeroRoles { get; set; }
        public List<Talent> Talents { get; set; }
        public Stat Stat { get; set; }
        [JsonProperty("language")]
        public HeroLanguage HeroLanguage { get; set; }
        public List<String> Aliases { get; set; }
    }
}