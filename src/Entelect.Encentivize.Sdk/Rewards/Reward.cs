namespace Entelect.Encentivize.Sdk.Rewards
{
    public class Reward
    {
        public long RewardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PointsCost { get; set; }
        public string TermsAndConditions { get; set; }
        public string PrimaryImageUrl { get; set; }
    }
}
