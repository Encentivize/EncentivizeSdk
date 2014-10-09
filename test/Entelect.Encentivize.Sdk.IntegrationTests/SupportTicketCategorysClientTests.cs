using Entelect.Encentivize.Sdk.SupportTickets.Categories;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class SupportTicketCategorysClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = SupportTicketCategoriesClient.Search(new SupportTicketCategorySearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = SupportTicketCategoriesClient.Get(1);
            Assert.NotNull(item);

        }
    }
}