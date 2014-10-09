namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public interface IGroupRolesClient
    {
        GroupRole Get(long groupRoleId);
        PagedResult<GroupRole> Search(GroupRoleSearchCriteria groupRoleSearchCriteria);
        GroupRole Create(GroupRoleInput groupRoleInput);
        GroupRole Update(long groupRoleId, GroupRoleInput groupRoleInput);
        GroupRole Update(GroupRole groupRole);
        void Delete(long groupRoleId);
        void Delete(GroupRole groupRole);
    }
}