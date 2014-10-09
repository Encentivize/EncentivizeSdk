using Entelect.Encentivize.Sdk.SupportTickets.Types;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class SupportTicketTypesClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = SupportTicketTypesClient.Search(new SupportTicketTypeSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = SupportTicketTypesClient.Get(1);
            Assert.NotNull(item);

        } 
    }
}