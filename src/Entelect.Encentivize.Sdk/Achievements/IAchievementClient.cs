namespace Entelect.Encentivize.Sdk.Achievements
{
    public interface IAchievementClient
    {
        Achievement Get(long achievementId);
        PagedResult<Achievement> Search(AchievementSearchCriteria achievementSearchCriteria);
        Achievement Create(AchievementInput achievementInput);
        Achievement Update(long achievementId, AchievementInput achievementInput);
        void Delete(long achievementId);
    }
}