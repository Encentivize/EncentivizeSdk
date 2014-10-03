using System;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategorySearchCriteria
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public DateTime? LastUpdatedDateUtcFrom { get; set; }
        public DateTime? LastUpdatedDateUtcTo { get; set; }
    }
}
