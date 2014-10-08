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

        public AchievementCategoryInput ToInput()
        {
            return new AchievementCategoryInput
            {
                Name = Name,
                Description = Description
            };
        }

        public string GetModificationUrl()
        {
            throw new NotImplementedException();
        }

        public string GetModificationUrl(string baseRoute)
        {
            return string.Format("{0}/{1}", baseRoute, AchievementCategoryId);
        }
    }
}