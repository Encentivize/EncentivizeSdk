using System;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.Members.Achievements;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class MemberAchievementClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var pagedAchievementCategory = MemberAchievementsClient.Search(new MemberAchievementSearchCriteria());
            Assert.NotNull(pagedAchievementCategory);
            Assert.Greater(pagedAchievementCategory.Data.Count, 0);
        }

        [Test]
        public void MemberAchievementHistory()
        {
            var pagedAchievementCategory = MemberAchievementsClient.SearchMembersAchievements(1, new MemberAchievementSearchCriteria());
            Assert.NotNull(pagedAchievementCategory);
            Assert.Greater(pagedAchievementCategory.Data.Count, 0);
        }

        [Test]
        public void AwardAchievemnt()
        {
            var createdAchievement = MemberAchievementsClient.AwardAchievement(1, GetMemberAchievementInput());
            Assert.NotNull(createdAchievement);
        }

        [Test]
        public void RetractAchievement()
        {
            var createdAchievement = MemberAchievementsClient.AwardAchievement(1, GetMemberAchievementInput());
            MemberAchievementsClient.RetractAchievement(1, createdAchievement.MemberAchievementId);
        }

        public MemberAchievementInput GetMemberAchievementInput()
        {
            var achievement = new AchievementClientTests().GetSomeEntity();
            return new MemberAchievementInput
            {
                AchievementId = achievement.AchievementId,
                AdditionalInformation = null,
                Comment = "test",
                DateAchievementEarnedUtc = DateTime.UtcNow,
                OverriddenPoints = null
            };
        }
    }
}