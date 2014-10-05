namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public interface IAchievementCategoryClient
    {
        AchievementCategoryOutput Get(long achievementCategoryId);
        AchievementCategoryOutput Create(AchievementCategoryInput achievementCategoryInput);
        AchievementCategoryOutput Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput);
        void Delete(long achievementCategoryId);
    }
}