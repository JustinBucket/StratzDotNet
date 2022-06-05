using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models.Rest
{
    public class Talent
    {
        public int Slot { get; set; }
        public int GameVersionId { get; set; }
        public int AbilityId { get; set; }
    }
}