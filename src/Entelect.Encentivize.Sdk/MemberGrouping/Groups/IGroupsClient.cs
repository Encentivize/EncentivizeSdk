namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public interface IGroupsClient
    {
        Group Get(long groupId);
        PagedResult<Group> Search(GroupSearchCriteria groupSearchCriteria);
        Group Create(GroupInput groupInput);
        Group Update(long groupId, GroupInput groupInput);
        void Delete(long groupId);
    }
}