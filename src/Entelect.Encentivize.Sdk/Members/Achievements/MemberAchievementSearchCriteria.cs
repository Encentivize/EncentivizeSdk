using System;

namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public class MemberAchievementSearchCriteria : BaseSearchCriteria
    {
        public long? AchievementId { get; set; }
        public long? MemberId { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public DateTime? LastUpdatedDateUtcFrom { get; set; }
        public DateTime? LastUpdatedDateUtcTo { get; set; }
        public int? UserAchievementStatusId { get; set; }
    }
}
