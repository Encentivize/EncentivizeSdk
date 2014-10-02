using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public class OtpRedeemRewardInput : RedeemRewardInput
    {
        [Required(ErrorMessage = "OtpCode is required.")]
        public int OtpCode { get; set; }
    }
}