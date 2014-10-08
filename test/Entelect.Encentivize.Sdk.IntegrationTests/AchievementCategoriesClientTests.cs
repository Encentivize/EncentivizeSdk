using System;
using System.Linq;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.Exceptions;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class AchievementCategoriesClientTests: SdkTestBase
    {
        [Test]
        public void GetById()
        {
            var achievementCategoryOutput = AchievementCategoriesClient.Get(2);
            Assert.NotNull(achievementCategoryOutput);
        }

        [Test]
        [ExpectedException(typeof(IdNotSetException))]
        public void GetByIdThatIsNegative()
        {
            var achievementCategoryOutput = AchievementCategoriesClient.Get(-1);
            Assert.NotNull(achievementCategoryOutput);
        }

        [Test]
        [ExpectedException(typeof(DataRetrievalFailedException))]
        public void GetByIdThatDoesntExist()
        {
            var achievementCategoryOutput = AchievementCategoriesClient.Get(int.MaxValue);
            Assert.NotNull(achievementCategoryOutput);
        }

        [Test]
        public void Search()
        {
            var pagedAchievementCategory = AchievementCategoriesClient.Search(new AchievementCategorySearchCriteria());
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
            AchievementCategoriesClient.Create(null);
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
            var updated = AchievementCategoriesClient.Update(existingItem.AchievementCategoryId, input);
            Assert.AreEqual(guid, updated.Name);
            Assert.AreEqual(guid, updated.Description);
        }

        [Test]
        public void Delete()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            AchievementCategoriesClient.Delete(existingItem.AchievementCategoryId);
        }

        public AchievementCategoryOutput GetSomeEntity()
        {
            var pagedAchievementCategoryResults = AchievementCategoriesClient.Search(new AchievementCategorySearchCriteria { PageSize = 1, PageNumber = 1 });
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
            return AchievementCategoriesClient.Create(input);
        }
    }
}
