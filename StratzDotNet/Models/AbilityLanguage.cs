using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratzDotNet.Models
{
    public class AbilityLanguage
    {
        public int AbilityId { get; set; }
        public int GameVersionId { get; set; }
        public int LanguageId { get; set; }
        public string DisplayName { get; set; }
        public string Lore { get; set; }
        [JsonProperty("description")]
        public string[] Descriptions { get; set; }
        public string[] Attributes { get; set; }
        public string[] Notes { get; set; }
    }
}