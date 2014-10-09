using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class OneTimePinPasswordResetInput : BaseInput
    {
        [Required(ErrorMessage = "OtpCode is required.")]
        public int OtpCode { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "User Name is required.")]
        public string UserIdentifier { get; set; }
    }
}