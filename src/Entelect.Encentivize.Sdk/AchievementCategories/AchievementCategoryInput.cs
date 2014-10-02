using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.AchievementCategories
{
    public class AchievementCategoryInput : BaseInput
    {
        [Required(ErrorMessage = "Achievement Category Id is required")]
        public long AchievementCategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}