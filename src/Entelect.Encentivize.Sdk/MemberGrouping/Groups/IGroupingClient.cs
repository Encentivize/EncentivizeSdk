using System.Collections.Generic;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;

namespace Entelect.Encentivize.Sdk.Grouping
{
    public interface IGroupingClient
    {
        List<GroupOutput> GetGroups();
        GroupOutput AddGroup(GroupOutput memberGroup);
        void UpdateGroup(GroupOutput memberGroup, int groupId);
        GroupOutput GetMemberGroup(int groupId);
    }
}