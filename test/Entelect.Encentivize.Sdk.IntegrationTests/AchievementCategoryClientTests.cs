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
            var achievementCategoryOutput = AchievementCategoryClient.Get(2);
            Assert.NotNull(achievementCategoryOutput);
        }

        [Test]
        [ExpectedException(typeof(IdNotSetException))]
        public void GetByIdThatIsNegative()
        {
            var achievementCategoryOutput = AchievementCategoryClient.Get(-1);
            Assert.NotNull(achievementCategoryOutput);
        }

        [Test]
        [ExpectedException(typeof(DataRetrievalFailedException))]
        public void GetByIdThatDoesntExist()
        {
            var achievementCategoryOutput = AchievementCategoryClient.Get(int.MaxValue);
            Assert.NotNull(achievementCategoryOutput);
        }

        [Test]
        public void Search()
        {
            var pagedAchievementCategory = AchievementCategoryClient.Search(new AchievementCategorySearchCriteria());
            Assert.NotNull(pagedAchievementCategory);
            Assert.Greater(pagedAchievementCategory.Data.Count, 0);
        }

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var createdAchievementCategoryOutput = CreateSomeEntity(guidString);
            Assert.NotNull(createdAchievementCategoryOutput);
            Assert.AreEqual(guidString, createdAchievementCategoryOutput.Name);
            Assert.AreEqual(guidString, createdAchievementCategoryOutput.Description);
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
            var existingItem = GetSomeEntity();
            var updated = AchievementCategoryClient.Update(existingItem.AchievementCategoryId, input);
            Assert.AreEqual(guid, updated.Name);
            Assert.AreEqual(guid, updated.Description);
        }

        [Test]
        public void Delete()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            AchievementCategoryClient.Delete(existingItem.AchievementCategoryId);
        }

        public AchievementCategoryOutput GetSomeEntity()
        {
            var pagedAchievementCategoryResults = AchievementCategoryClient.Search(new AchievementCategorySearchCriteria { PageSize = 1, PageNumber = 1 });
            var firstAchievementCategory = pagedAchievementCategoryResults.Data.FirstOrDefault();
            if (firstAchievementCategory == null)
            {
                firstAchievementCategory = CreateSomeEntity(Guid.NewGuid().ToString());
            }
            return firstAchievementCategory;
        }

        public AchievementCategoryOutput CreateSomeEntity(string guid)
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
