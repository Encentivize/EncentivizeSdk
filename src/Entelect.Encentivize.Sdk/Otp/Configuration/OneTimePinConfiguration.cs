namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfiguration: IEditableEntity<OneTimePinConfigurationInput>
    {
        public int OneTimePinTypeId { get; set; }

        public int MaxNumberOfRetries { get; set; }

        public bool IsActive { get; set; }

        public OneTimePinConfigurationInput ToInput()
        {
            return new OneTimePinConfigurationInput
            {
                IsActive = IsActive,
                MaxNumberOfRetries = MaxNumberOfRetries,
                OneTimePinTypeId = OneTimePinTypeId
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("OneTimePinConfigurations/{0}", OneTimePinTypeId);
        }
    }
}