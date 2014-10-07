using System.Linq;
using Entelect.Encentivize.Sdk.Members.Rewards;
using Entelect.Encentivize.Sdk.Rewards;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class MemberRewardsClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var results = MemberRewardsClient.Search(new RewardTransactionSearchCriteria());
            Assert.NotNull(results);
            Assert.Greater(results.Data.Count, 0);
        }

        [Test]
        public void MemberHistory()
        {
            var results = MemberRewardsClient.MemberHistory(1, new RewardTransactionSearchCriteria());
            Assert.NotNull(results);
            Assert.Greater(results.Data.Count, 0);
        }

        [Test]
        public void GetAvailableRewardsForMember()
        {
            var results = MemberRewardsClient.GetAvailableRewardsForMember(1, new RewardSearchCriteria());
            Assert.NotNull(results);
            Assert.Greater(results.Data.Count, 0);
        }

        [Test]
        public void RedeemReward()
        {
            var reward = MemberRewardsClient.GetAvailableRewardsForMember(1, new RewardSearchCriteria()).Data.First();
            var transaction = MemberRewardsClient.RedeemReward(1, new RedeemRewardInput
            {
                AdditionalInformation = null, 
                OverriddenPoints = null, 
                Quantity = 1, 
                RewardId = reward.RewardId
            });
            Assert.NotNull(transaction);
        }

        [Test]
        public void GetTransaction()
        {
            var rewardTransaction = MemberRewardsClient.Search(new RewardTransactionSearchCriteria()).Data.First();
            var sameTransaction = MemberRewardsClient.Get(rewardTransaction.MemberId, rewardTransaction.PointsTransactionsId);
            Assert.NotNull(sameTransaction);
            Assert.AreEqual(rewardTransaction.PointsTransactionsId, sameTransaction.PointsTransactionsId);
        }
    }
}