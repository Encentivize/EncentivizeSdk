namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public interface IAchievementCategoryClient
    {
        AchievementCategory Get(long achievementCategoryId);
        AchievementCategory Create(AchievementCategoryInput achievementCategoryInput);
        AchievementCategory Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput);
        void Delete(long achievementCategoryId);
    }
}