using System;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public class Group: IEditableEntity<GroupInput>
    {
        public long GroupId { get; set; }
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtc { get; set; }
        public bool IsActive { get; set; }

        public GroupInput ToInput()
        {
            return new GroupInput
            {
                Description = Description,
                GroupTypeId = GroupTypeId,
                IsActive = IsActive,
                Name = Name
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("Groups/{0}", GroupId);
        }
    }
}