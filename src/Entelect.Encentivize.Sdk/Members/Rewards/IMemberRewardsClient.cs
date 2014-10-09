using Entelect.Encentivize.Sdk.PointsTransactions;
using Entelect.Encentivize.Sdk.Rewards;

namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public interface IMemberRewardsClient
    {
        PagedResult<RewardTransaction> Search(RewardTransactionSearchCriteria rewardSearchCriteria);
        PagedResult<RewardTransaction> MemberHistory(long memberId, RewardTransactionSearchCriteria rewardSearchCriteria);
        PagedResult<RewardStructure> GetAvailableRewardsForMember(long memberId, RewardSearchCriteria rewardSearchCriteria);
        RewardTransaction RedeemReward(long memberId, RedeemRewardInput redeemRewardInput);
        RewardTransaction Get(long memberId, long rewardTransactionId);
        void RefundReward(long memberId, long rewardTransactionId);
        dynamic GetRewardAdditionalInformation(long memberId, long rewardTransactionId);
        dynamic UpdateRewardAdditionalInformation(long memberId, long rewardTransactionId, dynamic additionalInformation);
    }
}