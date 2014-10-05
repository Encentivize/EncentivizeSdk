namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRoleSearchCriteria : BaseSearchCriteria
    {
        public long? GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? AbilityId { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }
    }
}