using Entelect.Encentivize.Sdk.Members.Members;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class MemberClientTests : SdkTestBase
    {
        [Test]
        public void GetMe()
        {
            var me = MemberClient.GetMe();
            Assert.NotNull(me);
        }

        [Test]
        public void Search()
        {
            var results = MemberClient.Search(new MemberSearchCriteria());
            Assert.NotNull(results);
            Assert.NotNull(results.Data);
            Assert.Greater(results.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var me = MemberClient.Get(1);
            Assert.NotNull(me);
        }
    }
}