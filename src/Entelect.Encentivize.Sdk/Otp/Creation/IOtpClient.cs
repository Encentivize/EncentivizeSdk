namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public interface IOtpClient
    {
        void Create(CreateOtpRequest createOtpRequest);
        void PasswordReset(OtpPasswordResetInput otpPasswordResetInput);
    }
}