using System;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategory : IEditableEntity<AchievementCategoryInput>
    {
        public long AchievementCategoryId { get; set; }
        public int NumberOfAchievements { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtc { get; set; }

        public AchievementCategoryInput ToEditInput()
        {
            return new AchievementCategoryInput
            {
                Name = Name,
                Description = Description
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("AchievementCategories/{0}", AchievementCategoryId);
        }
    }
}