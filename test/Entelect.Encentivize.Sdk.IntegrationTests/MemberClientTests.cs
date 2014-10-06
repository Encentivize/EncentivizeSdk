using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class MemberClientTests : SdkTestBase
    {
        [Test]
        public void GetMemberByExternalReference()
        {
            MemberClient.GetMembers()
        }
    }
}