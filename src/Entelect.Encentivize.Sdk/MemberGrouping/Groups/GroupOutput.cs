using System;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public class GroupOutput
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
    }
}