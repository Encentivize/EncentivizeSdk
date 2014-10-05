namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public interface IGroupMembersClient
    {
        PagedResult<GroupMemberOutput> GetMembersInGroup(long groupId);
        GroupMemberOutput AddMemberToGroup(GroupMemberInput groupMemberInput, long groupId);
        GroupMemberOutput UpdateMemberRole(long groupId, GroupMemberInput groupMemberInput);
        void RemovedMemberFromGroup(long groupId, long memberId);
    }
}