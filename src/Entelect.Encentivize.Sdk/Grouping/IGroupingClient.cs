using System.Collections.Generic;
using Entelect.Encentivize.Sdk.Members.Members;

namespace Entelect.Encentivize.Sdk.Grouping
{
    public interface IGroupingClient
    {
        List<MemberGroup> GetGroups();
        MemberGroupDetails AddGroup(MemberGroup memberGroup);
        void UpdateGroup(MemberGroup memberGroup, int groupId);
        MemberGroup GetMemberGroup(int groupId);
        void DeleteMemberGroup(int groupId);
        List<MemberOutput> GetMembersInGroup(int groupId);
        void AddMemberToGroup(MemberGroupInput membergroup, int groupId);
        void RemoveMemberFromGroup(int groupId, int memberId);
        void UpdateMemberRole(int groupId, int MemberId, MemberGroupRoles role);
    }
}