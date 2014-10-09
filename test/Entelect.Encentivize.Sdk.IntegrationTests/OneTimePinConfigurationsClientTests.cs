using System;
using System.Linq;
using Entelect.Encentivize.Sdk.Otp.Configuration;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class OneTimePinConfigurationsClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = OneTimePinConfigurationsClient.Search(new OneTimePinConfigurationSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = OneTimePinConfigurationsClient.Get(1);
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
            var updated = OneTimePinConfigurationsClient.Update(new OneTimePinConfigurationInput
            {
                IsActive = !isActive,
                MaxNumberOfRetries = entity.MaxNumberOfRetries,
                OneTimePinTypeId = entity.OneTimePinTypeId
            });
            Assert.NotNull(updated);
            Assert.AreEqual(updated.IsActive, !isActive);
        }

        [Test]
        public void UpdateUsingEntity()
        {
            var entity = GetSomeEntity();
            entity.IsActive = !entity.IsActive;
            var updated = OneTimePinConfigurationsClient.Update(entity);
            Assert.NotNull(updated);
            Assert.AreEqual(updated.IsActive, entity.IsActive);
        }

        [Test]
        public void Delete()
        {
            var existingItem = GetSomeEntity();
            OneTimePinConfigurationsClient.Delete(existingItem.OneTimePinTypeId);
        }

        [Test]
        public void DeleteUsingEntity()
        {
            var existingItem = GetSomeEntity();
            OneTimePinConfigurationsClient.Delete(existingItem);
        }

        public OneTimePinConfiguration GetSomeEntity()
        {
            var pagedItems = OneTimePinConfigurationsClient.Search(new OneTimePinConfigurationSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity();
            }
            return firstItem;
        }

        public OneTimePinConfiguration CreateSomeEntity()
        {
            var itemToCreate = GetSomeInput();
            var config = OneTimePinConfigurationsClient.Get(itemToCreate.OneTimePinTypeId);
            if (config == null)
            {
                var createdItem = OneTimePinConfigurationsClient.Create(itemToCreate);
                return createdItem;
            }
            return config;
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