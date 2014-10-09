namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public interface IAchievementCategoriesClient
    {
        AchievementCategory Get(long achievementCategoryId);
        AchievementCategory Create(AchievementCategoryInput achievementCategoryInput);
        AchievementCategory Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput);
        AchievementCategory Update(AchievementCategory achievementCategory);
        void Delete(long achievementCategoryId);
        void Delete(AchievementCategory achievementCategory);
    }
}