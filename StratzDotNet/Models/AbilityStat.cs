using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StratzDotNet.Models
{
    public class AbilityStat
    {
        public int AbilityId { get; set; }
        public int GameVersionId { get; set; }
        public int Type { get; set; }
        public double Behavior { get; set; }
        public int UnitTargetType { get; set; }
        public int UnitTargetTeam { get; set; }
        public int UnitTargetFlags { get; set; }
        public int UnitDamageType { get; set; }
        public int SpellImmunity { get; set; }
        public double ModifierSupportValue { get; set; }
        public int ModifierSupportBonus { get; set; }
        public bool IsOnCastBar { get; set; }
        public bool IsOnLearnbar { get; set; }
        public int FightRecapLevel { get; set; }
        public bool IsGrantedByScepter { get; set; }
        public bool HasScepterUpgrade { get; set; }
        public int MaxLevel { get; set; }
        public int LevelsBetweenUpgrade { get; set; }
        public int RequiredLevel { get; set; }
        public bool DisplayAdditionalHeroes { get; set; }
        [JsonProperty("castRange")]
        public int[] CastRanges { get; set; }
        [JsonProperty("castRangeBuffer")]
        public int[] CastRangeBuffers { get; set; }
        [JsonProperty("castPoint")]
        public double[] CastPoints { get; set; }
        [JsonProperty("cooldown")]
        public double[] Cooldowns { get; set; }
        [JsonProperty("manaCost")]
        public double[] ManaCosts { get; set; }
        public bool IsUltimate { get; set; }
        public string Duration { get; set; }
        public string Charges { get; set; }
        public string ChargeRestoreTime { get; set; }
        public bool IsGrantedByShared { get; set; }
        public int Dispellable { get; set; }
           
    }
}