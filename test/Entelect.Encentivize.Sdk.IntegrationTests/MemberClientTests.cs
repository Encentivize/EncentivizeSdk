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
            var me = MembersClient.GetMe();
            Assert.NotNull(me);
        }

        [Test]
        public void Search()
        {
            var results = MembersClient.Search(new MemberSearchCriteria());
            Assert.NotNull(results);
            Assert.NotNull(results.Data);
            Assert.Greater(results.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var member = MembersClient.Get(1);
            Assert.NotNull(member);
        }

        [Test]
        public void Update()
        {
            var member = MembersClient.Get(2);
            var guidString = Guid.NewGuid().ToString();
            member.FirstName = guidString;
            var me = MembersClient.UpdateMember(member.MemberId, member.ToEditInput());
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
            var output = MembersClient.CreateMember(memeberInput);
            Assert.NotNull(output);
        }

        [Test]
        public void GetTimestoreForMember()
        {
            var data = MembersClient.GetTimestoreForMember(1);
        }

        [Test]
        public void SaveTimestoreForMember()
        {
            dynamic dataToSave = new System.Dynamic.ExpandoObject();
            var guidString = Guid.NewGuid().ToString();
            dataToSave.encentivizeId = "1";
            dataToSave.name = guidString;
            dataToSave.surname = guidString;
            dataToSave.mobile = "0825555555";
            dataToSave.email = guidString;
            MembersClient.WriteTimestoreForMember(1, dataToSave);
            var retrievedData = MembersClient.GetTimestoreForMember(1);
            Assert.AreEqual("1", retrievedData.encentivizeId.ToString());
            Assert.AreEqual(guidString, retrievedData.name.ToString());
            Assert.AreEqual(guidString, retrievedData.surname.ToString());
            Assert.AreEqual("0825555555", retrievedData.mobile.ToString());
            Assert.AreEqual(guidString, retrievedData.email.ToString());
            
        }

        [Test]
        public void ResetPasswordPin()
        {
            MembersClient.ResetPasswordPin(2);
        }
    }
}