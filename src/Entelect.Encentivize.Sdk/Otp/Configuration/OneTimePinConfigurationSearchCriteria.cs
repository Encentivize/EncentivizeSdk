namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfigurationSearchCriteria : BaseSearchCriteria
    {
        public long? OneTimePinTypeId { get; set; }

        public bool? IsActive { get; set; }
    }
}