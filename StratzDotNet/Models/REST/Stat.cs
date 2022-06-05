using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models.Rest
{
    public class Stat
    {
        public int GameVersionId { get; set; }
        public bool Enabled { get; set; }
        public double HeroUnlockOrder { get; set; }
        public bool Team { get; set; }
        public bool CmEnabled { get; set; }
        public bool NewPlayerEnabled { get; set; }
        public string AttackType { get; set; }
        public double StartingArmor { get; set; }
        public double StartingMagicArmor { get; set; }
        public double StartingDamageMin { get; set; }
        public double StartingDamageMax { get; set; }
        public double AttackRate { get; set; }
        public double AttackAnimationPoint { get; set; }
        public double AttackAcquisitionRange { get; set; }
        public double AttackRange { get; set; }
        public string PrimaryAttribute { get; set; }
        public int HeroPrimaryAttribute { get; set; }
        public double StrengthBase { get; set; }
        public double StrengthGain { get; set; }
        public double AgilityBase { get; set; }
        public double AgilityGain { get; set; }
        public double IntelligenceBase { get; set; }
        public double IntelligenceGain { get; set; }
        public double HpRegen { get; set; }
        public double MpRegen { get; set; }
        public double MoveSpeed { get; set; }
        public double MoveTurnRate { get; set; }
        public double HpBarOffset { get; set; }
        public double VisionDaytimeRange { get; set; }
        public double VisionNighttimeRange { get; set; }
        public int Complexity { get; set; }

    }
}