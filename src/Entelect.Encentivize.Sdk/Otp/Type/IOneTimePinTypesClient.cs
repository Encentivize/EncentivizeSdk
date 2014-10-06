namespace Entelect.Encentivize.Sdk.Otp.Type
{
    public interface IOneTimePinTypesClient
    {
        OneTimePinTypeOutput Get(long oneTimePinTypeId);
        PagedResult<OneTimePinTypeOutput> Search(OneTimePinTypeSearchCriteria oneTimePinTypeSearchCriteria);
    }
}