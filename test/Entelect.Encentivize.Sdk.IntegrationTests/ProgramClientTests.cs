using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class ProgramClientTests: SdkTestBase
    {
        [Test]
        public void Get()
        {
            var currentProgram = ProgramsClient.Get();
            Assert.NotNull(currentProgram);
        }
    }
}