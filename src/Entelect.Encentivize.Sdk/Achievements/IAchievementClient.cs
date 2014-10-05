namespace Entelect.Encentivize.Sdk.Achievements
{
    public interface IAchievementClient
    {
        AchievementOutput Get(long achievementId);
        PagedResult<AchievementOutput> Search(AchievementSearchCriteria achievementSearchCriteria);
        AchievementOutput Create(AchievementInput achievementInput);
        AchievementOutput Update(long achievementId, AchievementInput achievementInput);
        void Delete(long achievementId);
    }
}