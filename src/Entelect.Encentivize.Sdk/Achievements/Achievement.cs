namespace Entelect.Encentivize.Sdk.Achievements
{
    public class Achievement: IEditableEntity<AchievementInput>
    {
        public long AchievementId { get; set; }
        public long AchievementCategoryId { get; set; }
        public int AchievementCaptureTypeId { get; set; }
        public string Name { get; set; }
        public decimal DefaultPointsAwarded { get; set; }
        public string Description { get; set; }
        public string AchievementReferenceNumber { get; set; }
        public string TermsAndConditions { get; set; }
        public bool AllowOverriddenPoints { get; set; }
        public bool RequiresSignOff { get; set; }
        public string ImageUrl { get; set; }
        public long? DefaultRewardId { get; set; }

        public AchievementInput ToEditInput()
        {
            return new AchievementInput
            {
                AchievementCaptureTypeId = AchievementCaptureTypeId,
                AchievementCategoryId = AchievementCategoryId,
                AchievementReferenceNumber = AchievementReferenceNumber,
                AllowOverriddenPoints = AllowOverriddenPoints,
                DefaultPointsAwarded = DefaultPointsAwarded,
                DefaultRewardId = DefaultRewardId,
                Description = Description,
                ImageUrl = ImageUrl,
                Name = Name,
                RequiresSignOff = RequiresSignOff,
                TermsAndConditions = TermsAndConditions
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("Achievement/{0}", AchievementId);
        }
    }
}