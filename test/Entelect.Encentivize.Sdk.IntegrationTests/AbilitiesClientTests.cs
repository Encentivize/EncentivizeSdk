using Entelect.Encentivize.Sdk.MemberGrouping.Abilities;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class AbilitiesClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = AbilitiesClient.Search(new AbilitySearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = AbilitiesClient.Get(1);
            Assert.NotNull(item);
        }
    }
}