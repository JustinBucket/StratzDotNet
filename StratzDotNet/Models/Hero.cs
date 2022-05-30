using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Role> Roles { get; set; }
        public List<Talent> Talents { get; set; }
        public Stat Stat { get; set; }
        public Language Language { get; set; }
        public List<String> Aliases { get; set; }
    }
}