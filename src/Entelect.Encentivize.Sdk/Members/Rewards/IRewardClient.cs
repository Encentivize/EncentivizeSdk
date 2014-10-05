using Entelect.Encentivize.Sdk.Members.Rewards;

namespace Entelect.Encentivize.Sdk.Rewards
{
    public interface IRewardClient
    {
        PagedResult<RewardStructureOutput> GetAvailableRewardsForMember(long memberId);
        void RedeemReward(long memberId, long rewardId, int rewardCount);
    }
}