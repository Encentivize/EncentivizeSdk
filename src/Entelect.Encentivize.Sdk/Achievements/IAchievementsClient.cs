namespace Entelect.Encentivize.Sdk.Achievements
{
    public interface IAchievementsClient
    {
        Achievement Get(long achievementId);
        PagedResult<Achievement> Search(AchievementSearchCriteria achievementSearchCriteria);
        Achievement Create(AchievementInput achievementInput);
        Achievement Update(long achievementId, AchievementInput achievementInput);
        Achievement Update(Achievement achievement);
        void Delete(long achievementId);
        void Delete(Achievement achievement);
    }
}