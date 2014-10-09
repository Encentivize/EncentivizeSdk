using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public class AchievementInput : BaseInput
    {
        [Required(ErrorMessage = "Achievement Capture type id is required")]
        public int AchievementCaptureTypeId { get; set; }

        [Required(ErrorMessage = "Achievement Category Id is required")]
        public long AchievementCategoryId { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Default Points Awarded is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be a positive number")]
        public decimal DefaultPointsAwarded { get; set; }
        
        public long? DefaultRewardId { get; set; }

        [StringLength(50, ErrorMessage = "AchievementReferenceNumber cannot exceed 50 characters")]
        public string AchievementReferenceNumber { get; set; }

        [Required(ErrorMessage = "AllowOverriddenPoints is required")]
        public bool AllowOverriddenPoints { get; set; }

        [Required(ErrorMessage = "Requires Sign Off is required")]
        public bool RequiresSignOff { get; set; }

        [DataType("ImageUrl")]
        public string ImageUrl { get; set; }
        
        public string TermsAndConditions { get; set; }
    }
}