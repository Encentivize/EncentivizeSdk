using System;
using System.Linq;
using Entelect.Encentivize.Sdk.Otp.Configuration;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class OneTimePinConfigurationClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = OneTimePinConfigurationClient.Search(new OneTimePinConfigurationSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = OneTimePinConfigurationClient.Get(1);
            Assert.NotNull(item);
        }

        [Test]
        public void Create()
        {
            var createdItem = CreateSomeEntity();
            Assert.NotNull(createdItem);
            Assert.Greater(createdItem.OneTimePinTypeId, 0);
        }

        [Test]
        public void Update()
        {
            var entity = GetSomeEntity();
            var isActive = entity.IsActive;
            var updated = OneTimePinConfigurationClient.Update(GetSomeEntity().OneTimePinTypeId, new OneTimePinConfigurationInput
            {
                IsActive = !isActive,
                MaxNumberOfRetries = entity.MaxNumberOfRetries,
                OneTimePinTypeId = entity.OneTimePinTypeId
            });
            Assert.NotNull(updated);
            Assert.AreEqual(updated.IsActive, !isActive);
        }

        [Test]
        public void Delete()
        {
            var existingItem = GetSomeEntity();
            OneTimePinConfigurationClient.Delete(existingItem.OneTimePinTypeId);
        }

        public OneTimePinConfigurationOutput GetSomeEntity()
        {
            var pagedItems = OneTimePinConfigurationClient.Search(new OneTimePinConfigurationSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity();
            }
            return firstItem;
        }

        public OneTimePinConfigurationOutput CreateSomeEntity()
        {
            var itemToCreate = GetSomeInput();
            var createdItem = OneTimePinConfigurationClient.Create(itemToCreate);
            return createdItem;
        }

        public OneTimePinConfigurationInput GetSomeInput()
        {
            var itemToCreate = new OneTimePinConfigurationInput
            {
                IsActive = true,
                MaxNumberOfRetries = 3,
                OneTimePinTypeId = new Random().Next(1,3)
            };
            return itemToCreate;
        }
    }
}