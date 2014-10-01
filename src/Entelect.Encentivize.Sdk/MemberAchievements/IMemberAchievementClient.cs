using Entelect.Encentivize.Sdk.Members;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public interface IMemberAchievementClient
    {
        MemberAchievement AddAchievementForMember(long memberId, MemberAchievementInput memberAchievement);
        MemberAchievement AddAchievementForMember(Member member, MemberAchievementInput memberAchievement); 
    }
}