namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupTypeInput : BaseInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupCreationTypeId { get; set; }
        public int GroupLevel { get; set; }
    }
}