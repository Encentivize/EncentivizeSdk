namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupType : IEditableEntity<GroupTypeInput>
    {
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupCreationTypeId { get; set; }
        public int GroupLevel { get; set; }
        public GroupTypeInput ToInput()
        {
            return new GroupTypeInput
            {
                Description = Description,
                GroupCreationTypeId = GroupCreationTypeId,
                GroupLevel = GroupLevel,
                Name = Name
            };
        }

        public string GetModificationUrl()
        {
            throw new System.NotImplementedException();
        }
    }
}