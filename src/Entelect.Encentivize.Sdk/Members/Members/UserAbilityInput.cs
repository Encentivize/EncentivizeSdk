using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class UserAbilityInput
    {
        [Required(ErrorMessage = "UserId is required.")]
        public long UserId { get; set; }

        /// <summary>
        /// CanEarnPoints will default to true if not set.
        /// </summary>
        public bool? CanEarnPoints { get; set; }

        /// <summary>
        /// CanSpendPoints will default to true if not set.
        /// </summary>
        public bool? CanSpendPoints { get; set; }
    }
}