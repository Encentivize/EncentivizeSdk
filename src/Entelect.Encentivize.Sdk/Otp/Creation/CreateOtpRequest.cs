namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class CreateOtpRequest
    {
        public string UserIdentifier { get; set; }
        public int OtpTypeId { get; set; }
        public int ChannelTypeId { get; set; }
    }
}