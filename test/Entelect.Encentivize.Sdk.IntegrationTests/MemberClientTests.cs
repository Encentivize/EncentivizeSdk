using System;
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
            var member = MemberClient.Get(1);
            Assert.NotNull(member);
        }

        [Test]
        public void Update()
        {
            var member = MemberClient.Get(1);
            var guidString = Guid.NewGuid().ToString();
            member.FirstName = guidString;
            var me = MemberClient.UpdateMember(member.MemberId, member.ToInput());
            Assert.NotNull(me);
            Assert.AreEqual(guidString, me.FirstName);
        }
    }
}