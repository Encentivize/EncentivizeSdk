using System;
using System.Linq;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class GroupsClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = GroupsClient.Search(new GroupSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = GroupsClient.Get(1);
            Assert.NotNull(item);
        }

        [Test]
        public void GetGroupsForUser()
        {
            var groups = GroupsClient.GetGroupsForMember(1, new GroupMemberSearchCriteria());
            Assert.NotNull(groups);
            Assert.Greater(groups.Data.Count, 0);
        }

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var createdItem = CreateSomeEntity(guidString);
            Assert.NotNull(createdItem);
            Assert.Greater(createdItem.GroupId, 0);
        }

        [Test]
        public void Update()
        {
            var guid = Guid.NewGuid().ToString();
            var updated = GroupsClient.Update(GetSomeEntity().GroupId, GetSomeInput(guid));
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
            var updated = GroupsClient.Update(entity);
            Assert.NotNull(updated);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
        }

        [Test]
        public void Delete()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            GroupsClient.Delete(existingItem.GroupId);
        }

        [Test]
        public void DeleteUsingEntity()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            GroupsClient.Delete(existingItem);
        }

        public Group GetSomeEntity()
        {
            var pagedItems = GroupsClient.Search(new GroupSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity(Guid.NewGuid().ToString());
            }
            return firstItem;
        }

        public Group CreateSomeEntity(string guidString)
        {
            var itemToCreate = GetSomeInput(guidString);
            var createdItem = GroupsClient.Create(itemToCreate);
            return createdItem;
        }

        public GroupInput GetSomeInput(string guidString)
        {
            var type = new GroupTypesClientTests().GetSomeEntity();
            var itemToCreate = new GroupInput
            {
                GroupTypeId = type.GroupTypeId,
                Description = guidString,
                Name = guidString,
                IsActive = true
            };
            return itemToCreate;
        }
    }
}