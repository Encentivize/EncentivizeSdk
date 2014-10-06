namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public interface IMemberAchievementsClient
    {
        PagedResult<MemberAchievementOutput> Search(MemberAchievementSearchCriteria memberAchievementSearchCriteria);
        PagedResult<MemberAchievementOutput> SearchMembersAchievements(long memberId, MemberAchievementSearchCriteria memberAchievementSearchCriteria);
        MemberAchievementOutput AwardAchievement(long memberId, MemberAchievementInput memberAchievementInput);
        void Delete(long memberId, long memberAchievementId);
    }
}