using System;
using Entelect.Encentivize.Sdk.Members.Members;

namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public class AwardedAchievementOutput
    {
        public long MemberAchievementId { get; set; }
        public long AchievementId { get; set; }
        public AchievementStatus AchievementStatus { get; set; }
        public decimal PointsAwarded { get; set; }
        public long? RewardId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime DateAchievementEarnedUtc { get; set; }
        public long StructureId { get; set; }
        public MemberType MemberType { get; set; }
        public string AchievementReferenceNumber { get; set; }
        public long TimesAwarded { get; set; }
    }
}