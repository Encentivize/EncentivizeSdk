using System;
using System.Linq;
using Entelect.Encentivize.Sdk.Otp.Configuration;
using Entelect.Encentivize.Sdk.Otp.Type;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class OneTimePinTypesClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = OneTimePinTypesClient.Search(new OneTimePinTypeSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = OneTimePinTypesClient.Get(1);
            Assert.NotNull(item);
        }
    }
}