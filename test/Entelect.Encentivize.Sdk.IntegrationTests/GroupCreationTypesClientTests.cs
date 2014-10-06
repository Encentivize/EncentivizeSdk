using Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class GroupCreationTypesClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = GroupCreationTypesClient.Search(new GroupCreationTypeSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = GroupCreationTypesClient.Get(1);
            Assert.NotNull(item);
        }
    }
}