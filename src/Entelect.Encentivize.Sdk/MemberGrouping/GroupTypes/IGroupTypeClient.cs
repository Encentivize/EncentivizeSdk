namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public interface IGroupTypeClient
    {
        GroupType Get(long groupTypeId);
        PagedResult<GroupType> Search(GroupTypeSearchCriteria groupTypeSearchCriteria);
        GroupType Create(GroupTypeInput groupTypeInput);
        GroupType Update(long groupTypeId, GroupTypeInput groupTypeInput);
        void Delete(long groupTypeId);
    }
}