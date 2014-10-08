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

        [Test]
        public void GetPointsForMember()
        {
            var transactions = PointsClient.GetPointsForMember(1, new PointsTransactionSearchCriteria());
            Assert.NotNull(transactions);
            Assert.Greater(transactions.Data.Count, 0);
        }

        [Test]
        public void GetPointsForMe()
        {
            var transactions = PointsClient.GetPointsForMe(new PointsTransactionSearchCriteria());
            Assert.NotNull(transactions);
            Assert.Greater(transactions.Data.Count, 0);
        }

        [Test]
        public void AddAdhocPoints()
        {
            var transaction = PointsClient.AddAdhocPoints(2, new AdHocPointsInput
            {
                AdditionalInformation = null, 
                DisplayComment = "AutomatedTest", 
                PointsToAdd = 1
            });
            Assert.NotNull(transaction);
            Assert.AreEqual(1, transaction.PointsValue);
        }

        [Test]
        public void TransferPoints()
        {
            var transaction = PointsClient.TransferPoints(2, new TransferPointsInput
            {
                Comment = "Mine!",
                PointsToTransfer = 1,
                ToUserId = 1
            });
            Assert.NotNull(transaction);
            Assert.AreEqual(1, transaction.PointsTransfered);
        }
    }
}