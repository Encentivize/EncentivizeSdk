using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entelect.Encentivize.Sdk.Members;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.UnitTests
{
    [TestFixture]
    public class TimestoreTests
    {
        [Test]
        public void PostToTimestore()
        {
            const string username = "nolantheconqueror26@entelect.co.za";
            const string password = "adskjh4563!!";
            const string baseUrl = "https://wslots.encentivize.co.za/api/v1/";

            var encentivizeSettings = new EncentivizeSettings(username, password, baseUrl);
            var client = new MemberClient(encentivizeSettings);
            const int memberId = 72393;
            var timeStore = new
            {
                encentivizeId = "72393",
                mobile = "72393",
                firstname = "nolan",
                surname = "pather",
                additionalFields = new
                {
                    siteCode = "1606",
                    province = "WC",
                    sitename = "WC",
                    birthday = DateTime.UtcNow.ToString("o"),
                    lastQuestionSequence = 0
                }
            };
            client.WriteTimestoreForMember(memberId, timeStore);

            Assert.IsTrue(true);
        }
    }
}
