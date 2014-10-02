namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupTypeOutput
    {
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupCreationTypeId { get; set; }
        public int GroupLevel { get; set; }
    }
}