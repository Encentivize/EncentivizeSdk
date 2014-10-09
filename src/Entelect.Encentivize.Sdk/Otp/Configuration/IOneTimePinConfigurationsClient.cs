namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public interface IOneTimePinConfigurationsClient
    {
        OneTimePinConfiguration Get(long oneTimePinTypeId);
        PagedResult<OneTimePinConfiguration> Search(OneTimePinConfigurationSearchCriteria oneTimePinConfigurationSearchCriteria);
        OneTimePinConfiguration Create(OneTimePinConfigurationInput oneTimePinConfigurationInput);
        OneTimePinConfiguration Update(OneTimePinConfigurationInput oneTimePinConfigurationInput);
        OneTimePinConfiguration Update(OneTimePinConfiguration oneTimePinConfiguration);
        void Delete(long oneTimePinTypeId);
        void Delete(OneTimePinConfiguration oneTimePinConfiguration);
    }
}