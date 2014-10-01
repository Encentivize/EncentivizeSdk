namespace Entelect.Encentivize.Sdk.Achievements
{
    public class Achievement
    {
        public long AchievementId { get; set; }
        public long AchievementCategoryId { get; set; }
        public long AchievementCaptureTypeId { get; set; }
        public string Name { get; set; }
        public decimal DefaultPointsAwarded { get; set; }
        public string Description { get; set; }
        public string AchievementReferenceNumber { get; set; }
        public string TermsAndConditions { get; set; }
        public bool AllowOverriddenPoints { get; set; }
        public bool RequiresSignOff { get; set; }
        public string ImageUrl { get; set; }
        public long? DefaultRewardId { get; set; }
    }
}