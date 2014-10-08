using Entelect.Encentivize.Sdk.PointsTransactions;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class PointsClientTests : SdkTestBase
    {
        [Test]
        public void Get()
        {
            var transactions = PointsClient.Get(new PointsTransactionSearchCriteria());
            Assert.NotNull(transactions);
            Assert.Greater(transactions.Data.Count, 0);
        }
    }
}