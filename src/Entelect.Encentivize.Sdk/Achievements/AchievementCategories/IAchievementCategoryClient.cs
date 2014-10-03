namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public interface IAchievementCategoryClient
    {
        AchievementCategoryOutput GetById(long achievementCategoryId);
        AchievementCategoryOutput Create(AchievementCategoryInput achievementCategoryInput);
        AchievementCategoryOutput Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput);
        void Delete(long achievementCategoryId);
    }
}