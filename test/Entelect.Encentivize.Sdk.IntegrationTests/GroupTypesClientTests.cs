using System;
using System.Linq;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class GroupTypesClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = GroupTypesClient.Search(new GroupTypeSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var firstResult = GroupTypesClient.Search(new GroupTypeSearchCriteria()).Data.First();
            var item = GroupTypesClient.Get(firstResult.GroupTypeId);
            Assert.NotNull(item);
        }

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var createdItem = CreateSomeEntity(guidString);
            Assert.NotNull(createdItem);
            Assert.Greater(createdItem.GroupTypeId, 0);
        }

        [Test]
        public void Update()
        {
            var guid = Guid.NewGuid().ToString();
            var updated = GroupTypesClient.Update(GetSomeEntity().GroupTypeId, GetSomeInput(guid));
            Assert.NotNull(updated);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
        }

        [Test]
        public void UpdateUsingEntity()
        {
            var guid = Guid.NewGuid().ToString();
            var entity = GetSomeEntity();
            entity.Name = guid;
            entity.Description = guid;
            var updated = GroupTypesClient.Update(entity);
            Assert.NotNull(updated);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
        }

        [Test]
        public void Delete()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            GroupTypesClient.Delete(existingItem.GroupTypeId);
        }

        [Test]
        public void DeleteUsingEntity()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            GroupTypesClient.Delete(existingItem);
        }

        public GroupType GetSomeEntity()
        {
            var pagedItems = GroupTypesClient.Search(new GroupTypeSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity(Guid.NewGuid().ToString());
            }
            return firstItem;
        }

        public GroupType CreateSomeEntity(string guidString)
        {
            var itemToCreate = GetSomeInput(guidString);
            var createdItem = GroupTypesClient.Create(itemToCreate);
            return createdItem;
        }

        public GroupTypeInput GetSomeInput(string guidString)
        {
            var itemToCreate = new GroupTypeInput
            {
                Description = guidString,
                Name = guidString,
                GroupCreationTypeId = 1,
                GroupLevel = 1
            };
            return itemToCreate;
        }
    }
}