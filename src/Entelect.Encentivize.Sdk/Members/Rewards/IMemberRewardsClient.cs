using Entelect.Encentivize.Sdk.PointsTransactions;
using Entelect.Encentivize.Sdk.Rewards;

namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public interface IMemberRewardsClient
    {
        PagedResult<RewardTransactionOutput> Search(RewardTransactionSearchCriteria rewardSearchCriteria);
        PagedResult<RewardTransactionOutput> MemberHistory(long memberId, RewardTransactionSearchCriteria rewardSearchCriteria);
        PagedResult<RewardStructureOutput> GetAvailableRewardsForMember(long memberId, RewardSearchCriteria rewardSearchCriteria);
        RewardTransactionOutput RedeemReward(long memberId, RedeemRewardInput redeemRewardInput);
        RewardTransactionOutput Get(long memberId, long rewardTransactionId);
        void RefundReward(long memberId, long rewardTransactionId);
        dynamic GetRewardAdditionalInformation(long memberId, long rewardTransactionId);
        RewardTransactionOutput UpdateRewardAdditionalInformation(long memberId, long rewardTransactionId, dynamic additionalInformation);
    }
}