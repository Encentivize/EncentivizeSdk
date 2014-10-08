namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfiguration: IEditableEntity<OneTimePinConfigurationInput>
    {
        public int OneTimePinTypeId { get; set; }

        public int MaxNumberOfRetries { get; set; }

        public bool IsActive { get; set; }
        public OneTimePinConfigurationInput ToInput()
        {
            throw new System.NotImplementedException();
        }

        public string GetModificationUrl()
        {
            throw new System.NotImplementedException();
        }
    }
}