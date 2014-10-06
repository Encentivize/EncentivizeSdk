using System;
using System.Linq;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class GroupRolesClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = GroupRolesClient.Search(new GroupRoleSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = GroupRolesClient.Get(1);
            Assert.NotNull(item);
        }

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var createdItem = CreateSomeEntity(guidString);
            Assert.NotNull(createdItem);
            Assert.Greater(createdItem.GroupRoleId, 0);
        }

        [Test]
        public void Update()
        {
            var guid = Guid.NewGuid().ToString();
            var updated = GroupRolesClient.Update(GetSomeEntity().GroupRoleId, GetSomeInput(guid));
            Assert.NotNull(updated);
            Assert.AreEqual(updated.Name, guid);
            Assert.AreEqual(updated.Description, guid);
        }

        [Test]
        public void Delete()
        {
            var existingItem = CreateSomeEntity(Guid.NewGuid().ToString());
            GroupRolesClient.Delete(existingItem.GroupRoleId);
        }

        public GroupRoleOutput GetSomeEntity()
        {
            var pagedItems = GroupRolesClient.Search(new GroupRoleSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity(Guid.NewGuid().ToString());
            }
            return firstItem;
        }

        public GroupRoleOutput CreateSomeEntity(string guidString)
        {
            var itemToCreate = GetSomeInput(guidString);
            var createdItem = GroupRolesClient.Create(itemToCreate);
            return createdItem;
        }

        public GroupRoleInput GetSomeInput(string guidString)
        {
            var groupType = new GroupTypesClientTests().GetSomeEntity();
            var itemToCreate = new GroupRoleInput
            {
                Description = guidString,
                Name = guidString,
                Abilities = new[] { 1 },
                GroupTypeId = groupType.GroupTypeId
            };
            return itemToCreate;
        }
    }
}