namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfigurationOutput
    {
        public int OneTimePinTypeId { get; set; }

        public int MaxNumberOfRetries { get; set; }

        public bool IsActive { get; set; }
    }
}