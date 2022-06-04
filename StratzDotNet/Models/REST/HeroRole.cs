using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models
{
    public class HeroRole
    {
        public int RoleId { get; set; }
        public int Level { get; set; }
        public int HeroId { get; set; }
        public int GameVersionId { get; set; }
    }
}