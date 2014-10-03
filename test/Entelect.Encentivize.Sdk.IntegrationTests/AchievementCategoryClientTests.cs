using System;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.Exceptions;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class AchievementCategoryClientTests: SdkTestBase
    {
        [Test]
        public void GetById()
        {
            var achievement = AchievementCategoryClient.GetById(2);
            Assert.NotNull(achievement);
        }

        [Test]
        [ExpectedException(typeof(DataRetrievalFailedException))]
        public void GetByIdThatDoesntExist()
        {
            var achievement = AchievementCategoryClient.GetById(-1);
            Assert.NotNull(achievement);
        }

        [Test]
        public void FindAll()
        {
            var pagedAchievements = AchievementCategoryClient.Search(new AchievementCategorySearchCriteria {PageSize = 1, PageNumber = 2});
            Assert.NotNull(pagedAchievements);
            Assert.Greater(pagedAchievements.Data.Count, 0);
        }


        [Test]
        public void Create()
        {
            var guid = Guid.NewGuid().ToString();
            var input = new AchievementCategoryInput
            {
                Name = guid,
                Description = guid
            };
            var createdAchievement = AchievementCategoryClient.Create(input);
            Assert.NotNull(createdAchievement);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateWithNoBody()
        {
            AchievementCategoryClient.Create(null);
        }
    }
}