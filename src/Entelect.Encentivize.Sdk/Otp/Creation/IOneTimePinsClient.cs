namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public interface IOneTimePinsClient
    {
        void Create(CreateOneTimePinRequest createOneTimePinRequest);
        void PasswordReset(OneTimePinPasswordResetInput oneTimePinPasswordResetInput);
    }
}