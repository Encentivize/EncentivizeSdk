using System.Collections.Generic;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using Entelect.Encentivize.Sdk.Members.Members;

namespace Entelect.Encentivize.Sdk.Grouping
{
    public interface IGroupingClient
    {
        List<GroupOutput> GetGroups();
        GroupOutput AddGroup(GroupOutput memberGroup);
        void UpdateGroup(GroupOutput memberGroup, int groupId);
        GroupOutput GetMemberGroup(int groupId);
        void DeleteMemberGroup(int groupId);
        List<MemberOutput> GetMembersInGroup(int groupId);
        void AddMemberToGroup(MemberGroupInput membergroup, int groupId);
    }
}