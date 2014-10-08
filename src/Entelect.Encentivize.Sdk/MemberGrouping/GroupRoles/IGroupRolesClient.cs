namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public interface IGroupRolesClient
    {
        GroupRole Get(long groupRoleId);
        PagedResult<GroupRole> Search(GroupRoleSearchCriteria groupRoleSearchCriteria);
        GroupRole Create(GroupRoleInput groupRoleInput);
        GroupRole Update(long groupRoleId, GroupRoleInput groupRoleInput);
        void Delete(long groupRoleId);
    }
}