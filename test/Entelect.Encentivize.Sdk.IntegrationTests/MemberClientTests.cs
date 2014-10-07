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

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var memeberInput = new MemberInput
                               {
                                   CanEarnPoints = true,
                                   CanSpendPoints = true,
                                   EmailAddress = guidString,
                                   ExternalReferenceCode = guidString,
                                   FirstName = guidString,
                                   MemberStatusId = 1,
                                   MemberTypeId = 1,
                                   MobileNumber = guidString.Substring(0,15),
                                   ProfilePictureUrl = null,
                                   StructureId = 1,
                                   Surname = guidString,
                               };
            var output = MemberClient.CreateMember(memeberInput);
            Assert.NotNull(output);
        }

        [Test]
        public void GetTimestoreForMember()
        {
            var data = MemberClient.GetTimestoreForMember(1);
        }

        [Test]
        public void SaveTimestoreForMember()
        {
            dynamic dataToSave = new {SomeThing = "Word", ABool = true};
            var data = MemberClient.WriteTimestoreForMember(1, dataToSave);
            var retrievedData = MemberClient.GetTimestoreForMember(1);
            Assert.AreEqual("Word", retrievedData.SomeThing);
            Assert.AreEqual(true, retrievedData.ABool);
        }
    }
}