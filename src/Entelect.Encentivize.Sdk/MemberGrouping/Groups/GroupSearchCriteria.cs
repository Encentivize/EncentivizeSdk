namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public class GroupSearchCriteria : BaseSearchCriteria
    {
        public long? GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? CreatedById { get; set; }
        public long? LastUpdatedById { get; set; }
        public bool? IsActive { get; set; }
    }
}