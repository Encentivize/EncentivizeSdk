using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class CreateOneTimePinRequest: BaseInput
    {
        [Required]
        public string UserIdentifier { get; set; }
        [Required]
        public int OtpTypeId { get; set; }
        [Required]
        public int ChannelTypeId { get; set; }
    }
}