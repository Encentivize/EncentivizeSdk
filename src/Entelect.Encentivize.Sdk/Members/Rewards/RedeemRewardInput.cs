namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public class RedeemRewardInput
    {
        public long RewardId { get; set; }
        public int Quantity { get; set; }
        public dynamic AdditionalInformation { get; set; }
        public decimal? OverriddenPoints { get; set; }
    }
}