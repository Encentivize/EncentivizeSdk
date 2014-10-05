namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes
{
    public interface IGroupCreationTypesClient
    {
        GroupCreationTypeOutput Get(long groupCreationTypeId);
        PagedResult<GroupCreationTypeOutput> Search(GroupCreationTypeSearchCriteria groupCreationTypeSearchCriteria);
    }
}