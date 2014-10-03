using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class QueryStringBuilderTests
    {
        [Test]
        public void OnlyNameSet()
        {
            var queryStringBuilder = new QueryStringBuilder();
            var objectToConvert = new TestSerialisationObject {Name = "test"};
            var queryString = queryStringBuilder.ToQueryString(objectToConvert);
            StringAssert.AreEqualIgnoringCase("name=test",queryString);
        }

        [Test]
        public void NameAndIdSet()
        {
            var queryStringBuilder = new QueryStringBuilder();
            var objectToConvert = new TestSerialisationObject { Name = "test" ,Id=1};
            var queryString = queryStringBuilder.ToQueryString(objectToConvert);
            StringAssert.AreEqualIgnoringCase("name=test&id=1", queryString);
        }
    }
}