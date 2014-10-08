namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupType : IEditableEntity<GroupTypeInput>
    {
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupCreationTypeId { get; set; }
        public int GroupLevel { get; set; }
        public GroupTypeInput ToInput()
        {
            throw new System.NotImplementedException();
        }

        public string GetModificationUrl()
        {
            throw new System.NotImplementedException();
        }
    }
}