namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public interface IGroupRolesClient
    {
        GroupRoleOutput Get(long groupRoleId);
        PagedResult<GroupRoleOutput> Search(GroupRoleSearchCriteria groupRoleSearchCriteria);
        GroupRoleOutput Create(GroupRoleInput groupRoleInput);
        GroupRoleOutput Update(long groupRoleId, GroupRoleInput groupRoleInput);
        void Delete(long groupRoleId);
    }
}