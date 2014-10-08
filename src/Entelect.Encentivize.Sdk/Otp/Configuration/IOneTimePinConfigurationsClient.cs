namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public interface IOneTimePinConfigurationsClient
    {
        OneTimePinConfiguration Get(long oneTimePinTypeId);
        PagedResult<OneTimePinConfiguration> Search(OneTimePinConfigurationSearchCriteria oneTimePinConfigurationSearchCriteria);
        OneTimePinConfiguration Create(OneTimePinConfigurationInput oneTimePinConfigurationInput);
        OneTimePinConfiguration Update(OneTimePinConfigurationInput oneTimePinConfigurationInput);
        void Delete(long oneTimePinTypeId);
    }
}