namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public interface IGroupMembersClient
    {
        PagedResult<GroupMember> GetMembersInGroup(long groupId);
        GroupMember AddMemberToGroup(GroupMemberInput groupMemberInput, long groupId);
        GroupMember UpdateMemberRole(long groupId, GroupMemberInput groupMemberInput);
        void RemovedMemberFromGroup(long groupId, long memberId);
    }
}