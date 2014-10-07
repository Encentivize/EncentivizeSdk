using Entelect.Encentivize.Sdk.Members.Rewards;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class MemberRewardsClientTests : SdkTestBase
    {
        public MemberRewardsClientTests()
        {
            
        }

        [Test]
        public void Search()
        {
            var results = MemberRewardsClient.Search(new RewardTransactionSearchCriteria());
            Assert.NotNull(results);
            Assert.Greater(results.Data.Count, 0);
        }
    }
}