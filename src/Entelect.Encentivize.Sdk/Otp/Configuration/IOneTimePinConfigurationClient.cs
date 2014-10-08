namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public interface IOneTimePinConfigurationClient
    {
        OneTimePinConfigurationOutput Get(long oneTimePinTypeId);
        PagedResult<OneTimePinConfigurationOutput> Search(OneTimePinConfigurationSearchCriteria oneTimePinConfigurationSearchCriteria);
        OneTimePinConfigurationOutput Create(OneTimePinConfigurationInput oneTimePinConfigurationInput);
        OneTimePinConfigurationOutput Update(OneTimePinConfigurationInput oneTimePinConfigurationInput);
        void Delete(long oneTimePinTypeId);
    }
}