using System;

namespace Entelect.Encentivize.Sdk.Rewards
{
    public class RewardStructureOutput
    {
        public long RewardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TermsAndConditions { get; set; }
        public string PrimaryImageUrl { get; set; }
        public decimal PointsCost { get; set; }
        public long? QuantityLimitTimeFrame { get; set; }
        public int? QuantityLimit { get; set; }
        public DateTime ValidToDateUtc { get; set; }
        public DateTime ValidFromDateUtc { get; set; }
    }
}