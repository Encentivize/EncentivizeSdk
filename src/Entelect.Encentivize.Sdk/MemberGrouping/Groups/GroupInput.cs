namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public class GroupInput : BaseInput
    {
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}