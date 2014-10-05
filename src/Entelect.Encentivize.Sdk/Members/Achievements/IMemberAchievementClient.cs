namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public interface IMemberAchievementClient
    {
        AwardedAchievementOutput AddAchievementForMember(long memberId, AwardedAchievementInput memberAchievement);
    }
}