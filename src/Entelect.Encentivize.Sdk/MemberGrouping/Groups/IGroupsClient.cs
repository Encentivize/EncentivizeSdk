namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public interface IGroupsClient
    {
        Group Get(long groupId);
        PagedResult<Group> Search(GroupSearchCriteria groupSearchCriteria);
        Group Create(GroupInput groupInput);
        Group Update(long groupId, GroupInput groupInput);
        Group Update(Group group);
        void Delete(long groupId);
        void Delete(Group group);
    }
}