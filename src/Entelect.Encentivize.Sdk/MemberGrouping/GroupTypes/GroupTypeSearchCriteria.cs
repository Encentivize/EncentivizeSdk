namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupTypeSearchCriteria : BaseSearchCriteria
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long? GroupCreationTypeId { get; set; }
        public int? GroupLevel { get; set; }
    }
}