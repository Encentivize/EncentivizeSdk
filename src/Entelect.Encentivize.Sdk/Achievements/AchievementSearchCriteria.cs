using System;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public class AchievementSearchCriteria : BaseSearchCriteria
    {
        public long? AchievementId { get; set; }
        public long? DefaultRewardId { get; set; }
        public int? DefaultPointsLower { get; set; }
        public int? DefaultPointsUpper { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AchievementReferenceNumber { get; set; }
        public string TermsAndConditions { get; set; }
        public bool? RequiresSignOff { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtcFrom { get; set; }
        public DateTime? LastUpdatedDateUtcTo { get; set; }
        public long? EmployeeTypeId { get; set; }
    }
}