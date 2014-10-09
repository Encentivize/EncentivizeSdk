namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes
{
    public interface IGroupCreationTypesClient
    {
        GroupCreationType Get(long groupCreationTypeId);
        PagedResult<GroupCreationType> Search(GroupCreationTypeSearchCriteria groupCreationTypeSearchCriteria);
    }
}