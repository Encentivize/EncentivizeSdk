using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Entelect.Encentivize.Sdk.Achievements;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class AchievementClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = AchievementClient.Search(new AchievementSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = AchievementClient.Get(10);
            Assert.NotNull(item);
        }

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var createdItem = CreateSomeEntity(guidString);
            Assert.NotNull(createdItem);
            Assert.Greater(createdItem.AchievementId, 0);
        }

        [Test]
        public void Update()
        {
            var guid = Guid.NewGuid().ToString();
            var updated = AchievementClient.Update(GetSomeEntity().AchievementId, GetSomeInput(guid));
            Assert.NotNull(updated);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
            Assert.AreEqual(updated.AchievementReferenceNumber, guid);
            Assert.AreEqual(updated.TermsAndConditions, guid);
        }

        [Test]
        public void Delete()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            AchievementClient.Delete(existingItem.AchievementId);
        }

        public AchievementOutput GetSomeEntity()
        {
            var pagedItems = AchievementClient.Search(new AchievementSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity(Guid.NewGuid().ToString());
            }
            return firstItem;
        }

        public AchievementOutput CreateSomeEntity(string guidString)
        {
            var itemToCreate = GetSomeInput(guidString);
            var createdItem = AchievementClient.Create(itemToCreate);
            return createdItem;
        }

        public AchievementInput GetSomeInput(string guidString)
        {
            var someAchievementCategory = new AchievementCategoryClientTests().GetSomeEntity();
            var itemToCreate = new AchievementInput
            {
                AchievementCaptureTypeId = 1,
                AchievementReferenceNumber = guidString,
                AllowOverriddenPoints = true,
                DefaultPointsAwarded = 1,
                DefaultRewardId = null,
                Description = guidString,
                Name = guidString,
                RequiresSignOff = true,
                ImageUrl = null,
                TermsAndConditions = guidString,
                AchievementCategoryId = someAchievementCategory.AchievementCategoryId
            };
            return itemToCreate;
        }
    }
}