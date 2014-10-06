using System;
using System.Linq;
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
            var achievement = AchievementCategoryClient.Get(2);
            Assert.NotNull(achievement);
        }

        [Test]
        [ExpectedException(typeof(IdNotSetException))]
        public void GetByIdThatIsNegative()
        {
            var achievement = AchievementCategoryClient.Get(-1);
            Assert.NotNull(achievement);
        }

        [Test]
        [ExpectedException(typeof(DataRetrievalFailedException))]
        public void GetByIdThatDoesntExist()
        {
            var achievement = AchievementCategoryClient.Get(int.MaxValue);
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
            var guidString = Guid.NewGuid().ToString();
            var createdAchievement = CreateSomeCategory(guidString);
            Assert.NotNull(createdAchievement);
            Assert.AreEqual(guidString, createdAchievement.Name);
            Assert.AreEqual(guidString, createdAchievement.Description);
        }
        

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateWithNoBody()
        {
            AchievementCategoryClient.Create(null);
        }

        [Test]
        public void Update()
        {
            var guid = Guid.NewGuid().ToString();
            var input = new AchievementCategoryInput
            {
                Description = guid,
                Name = guid
            };
            var updated = AchievementCategoryClient.Update(GetSomeAchievementCategory().AchievementCategoryId, input);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
        }

        [Test]
        public void Delete()
        {
            var guid = Guid.NewGuid().ToString();
            var input = new AchievementCategoryInput
            {
                Description = guid,
                Name = guid
            };
            var updated = AchievementCategoryClient.Update(GetSomeAchievementCategory().AchievementCategoryId, input);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
        }

        private AchievementCategoryOutput GetSomeAchievementCategory()
        {
            var pagedAchievements = AchievementCategoryClient.Search(new AchievementCategorySearchCriteria { PageSize = 1, PageNumber = 1 });
            var firstAchievementCategory = pagedAchievements.Data.FirstOrDefault();
            if (firstAchievementCategory == null)
            {
                firstAchievementCategory = CreateSomeCategory(Guid.NewGuid().ToString());
            }
            return firstAchievementCategory;
        }

        private AchievementCategoryOutput CreateSomeCategory(string guid)
        {
            var input = new AchievementCategoryInput
            {
                Name = guid,
                Description = guid
            };
            return AchievementCategoryClient.Create(input);
        }
    }
}
