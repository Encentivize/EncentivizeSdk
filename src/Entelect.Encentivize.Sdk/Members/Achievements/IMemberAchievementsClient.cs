namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public interface IMemberAchievementsClient
    {
        PagedResult<MemberAchievement> Search(MemberAchievementSearchCriteria memberAchievementSearchCriteria);
        PagedResult<MemberAchievement> SearchMembersAchievements(long memberId, MemberAchievementSearchCriteria memberAchievementSearchCriteria);
        MemberAchievement AwardAchievement(long memberId, MemberAchievementInput memberAchievementInput);
        void RetractAchievement(long memberId, long memberAchievementId);
    }
}