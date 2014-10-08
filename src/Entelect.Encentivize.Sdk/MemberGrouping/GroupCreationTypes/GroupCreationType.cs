namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes
{
    public class GroupCreationType : IEntity
    {
        public int GroupCreationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}