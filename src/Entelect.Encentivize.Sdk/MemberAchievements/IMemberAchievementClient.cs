using Entelect.Encentivize.Sdk.Members.Members;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public interface IMemberAchievementClient
    {
        MemberAchievement AddAchievementForMember(long memberId, MemberAchievementInput memberAchievement);
    }
}