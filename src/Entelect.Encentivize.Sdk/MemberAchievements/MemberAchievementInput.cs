using System;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public class MemberAchievementInput
    {
        public long AchievementId { get; set; }
        public decimal? OverriddenPoints { get; set; }
        public DateTime DateAchievementEarnedUtc { get; set; }
        public string Comment { get; set; }
    }
}
