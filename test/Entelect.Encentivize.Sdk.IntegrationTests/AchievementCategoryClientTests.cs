using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class AchievementCategoryClientTests: SdkTestBase
    {
        [Test]
        public void GetById()
        {
            var achievement = AchievementCategoryClient.GetById(1);
            Assert.NotNull(achievement);
        }
    }
}