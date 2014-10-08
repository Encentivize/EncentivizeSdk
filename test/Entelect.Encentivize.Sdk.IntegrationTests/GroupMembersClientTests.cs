using System.Linq;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class GroupMembersClientTests : SdkTestBase
    {
        const int MemberId = 16;

        [Test]
        public void GetMembersInGroup()
        {
            var searchResult = GroupMembersClient.GetMembersInGroup(SomeGroup().GroupId);
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void RemoveUserFromGroup()
        {
            var groupMembers = GroupMembersClient.GetMembersInGroup(SomeGroup().GroupId);
            var firstMemberInGroup = groupMembers.Data.First();
            if (firstMemberInGroup == null)
            {
                firstMemberInGroup = GroupMembersClient.AddMemberToGroup(new GroupMemberInput {MemberId = MemberId}, SomeGroup().GroupId);
            }
            GroupMembersClient.RemovedMemberFromGroup(SomeGroup().GroupId, firstMemberInGroup.Member.MemberId);
        }

        [Test]
        public void AddMemberToGroup()
        {
            var memberMapping = new GroupMemberInput {MemberId = MemberId};
            var groupMembers = GroupMembersClient.GetMembersInGroup(SomeGroup().GroupId);
            if (groupMembers.Data.Any(output => output.Member.MemberId == MemberId))
            {
                GroupMembersClient.RemovedMemberFromGroup(SomeGroup().GroupId, MemberId);
            }
            var groupMemberOutput = GroupMembersClient.AddMemberToGroup(memberMapping,SomeGroup().GroupId);
            Assert.NotNull(groupMemberOutput);
            Assert.AreEqual(groupMemberOutput.Member.MemberId, MemberId);
        }

        [Test]
        public void UpdateMemberRole()
        {
            var groupMembers = GroupMembersClient.GetMembersInGroup(SomeGroup().GroupId);
            var firstMemberInGroup = groupMembers.Data.FirstOrDefault();
            if (firstMemberInGroup == null)
            {
                firstMemberInGroup = GroupMembersClient.AddMemberToGroup(new GroupMemberInput { MemberId = MemberId }, SomeGroup().GroupId);
            }
            long? roleId;
            if (firstMemberInGroup.GroupRoleId.HasValue)
            {
                roleId = null;
            }
            else
            {
                roleId = new GroupRolesClientTests().GetSomeEntity().GroupRoleId;
            }
            var output = GroupMembersClient.UpdateMemberRole(SomeGroup().GroupId, new GroupMemberInput {GroupRoleId = roleId, MemberId = firstMemberInGroup.Member.MemberId});
            Assert.NotNull(output);
            Assert.AreEqual(roleId,output.GroupRoleId);
            Assert.AreEqual(firstMemberInGroup.Member.MemberId, output.Member.MemberId);
        }

        public Group SomeGroup()
        {
            return new GroupsClientTests().GetSomeEntity();
        }
    }
}