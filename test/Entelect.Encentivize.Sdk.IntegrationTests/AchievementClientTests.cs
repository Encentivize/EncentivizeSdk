using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.UnitTests
{
    public class AchievementClientTests : SdkTestBase
    {
        [Test]
        public void GetAchievementById()
        {
            var achievement = AchievementClient.GetById(1);
            Assert.NotNull(achievement);
        }
    }
}