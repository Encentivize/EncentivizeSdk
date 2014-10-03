using System;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategoryOutput
    {
        public long AchievementCategoryId { get; set; }
        public int NumberOfAchievements { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtc { get; set; }
    }
}