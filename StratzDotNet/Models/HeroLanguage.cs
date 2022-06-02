using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models
{
    public class HeroLanguage
    {
        public int HeroId { get; set; }
        public int GameVersionId { get; set; }
        public int LanguageId { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Hype { get; set; }
    }
}