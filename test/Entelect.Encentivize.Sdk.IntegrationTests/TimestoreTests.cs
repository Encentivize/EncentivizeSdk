//using System;
//using NUnit.Framework;

//namespace Entelect.Encentivize.Sdk.IntegrationTests
//{
//    [TestFixture]
//    public class TimestoreTests : SdkTestBase
//    {
//        [Test]
//        public void PostToTimestore()
//        {
//            const int memberId = 66;
//            var timeStore = new
//            {
//                encentivizeId = "66",
//                mobile = "66",
//                firstname = "nolan",
//                surname = "pather",
//                additionalFields = new
//                {
//                    siteCode = "1606",
//                    province = "WC",
//                    sitename = "WC",
//                    birthday = DateTime.UtcNow.ToString("o"),
//                    lastQuestionSequence = 0
//                }
//            };
//            MemberClient.WriteTimestoreForMember(memberId, timeStore);

//            Assert.IsTrue(true);
//        }

//        [Test]
//        public void GetFromTimestore()
//        {
//            var returnedData = MemberClient.GetTimestoreForMember(1);
//            Assert.IsNotNull(returnedData);
//        }
//    }
//}
