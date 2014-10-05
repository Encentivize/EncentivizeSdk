namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public interface IGroupsClient
    {
        GroupOutput Get(long groupId);
        PagedResult<GroupOutput> Search(GroupSearchCriteria groupSearchCriteria);
        GroupOutput Create(GroupInput groupInput);
        GroupOutput Update(long groupId, GroupInput groupInput);
        void Delete(long groupId);
    }
}