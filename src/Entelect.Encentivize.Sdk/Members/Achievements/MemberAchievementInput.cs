using System;
using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public class MemberAchievementInput : BaseInput
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long AchievementId { get; set; }
        [Range(0, long.MaxValue)]
        public decimal? OverriddenPoints { get; set; }
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2100-01-01")]
        public DateTime DateAchievementEarnedUtc { get; set; }
        [Required]
        [MinLength(1)]
        public string Comment { get; set; }

        public dynamic AdditionalInformation { get; set; }
    }
}