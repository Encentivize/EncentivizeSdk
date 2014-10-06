using System;
using System.Linq;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
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
            GroupMembersClient.RemovedMemberFromGroup(SomeGroup().GroupId, firstMemberInGroup.MemberOutput.MemberId);
        }

        [Test]
        public void AddMemberToGroup()
        {
            var memberMapping = new GroupMemberInput {MemberId = MemberId};
            var groupMembers = GroupMembersClient.GetMembersInGroup(SomeGroup().GroupId);
            if (groupMembers.Data.Any(output => output.MemberOutput.MemberId == MemberId))
            {
                GroupMembersClient.RemovedMemberFromGroup(SomeGroup().GroupId, MemberId);
            }
            var groupMemberOutput = GroupMembersClient.AddMemberToGroup(memberMapping,SomeGroup().GroupId);
            Assert.NotNull(groupMemberOutput);
            Assert.AreEqual(groupMemberOutput.MemberOutput.MemberId, MemberId);
        }

        [Test]
        public void UpdateMemberRole()
        {
            var groupMembers = GroupMembersClient.GetMembersInGroup(SomeGroup().GroupId);
            var firstMemberInGroup = groupMembers.Data.First();
            long? roleId;
            if (firstMemberInGroup.GroupRoleId.HasValue)
            {
                roleId = null;
            }
            else
            {
                roleId = new GroupRolesClientTests().GetSomeEntity().GroupRoleId;
            }
            var output = GroupMembersClient.UpdateMemberRole(SomeGroup().GroupId, new GroupMemberInput {GroupRoleId = roleId, MemberId = firstMemberInGroup.MemberOutput.MemberId});
            Assert.NotNull(output);
            Assert.AreEqual(roleId,output.GroupRoleId);
            Assert.AreEqual(firstMemberInGroup.MemberOutput.MemberId, output.MemberOutput.MemberId);
        }

        public GroupOutput SomeGroup()
        {
            return new GroupsClientTests().GetSomeEntity();
        }
    }
}