using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfigurationInput : BaseInput
    {
        [Required]
        public int OneTimePinTypeId { get; set; }

        [Required]
        [Range(1,10)]
        public int MaxNumberOfRetries { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}