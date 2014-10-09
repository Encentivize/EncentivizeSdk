namespace Entelect.Encentivize.Sdk.Otp.Type
{
    public interface IOneTimePinTypesClient
    {
        OneTimePinType Get(long oneTimePinTypeId);
        PagedResult<OneTimePinType> Search(OneTimePinTypeSearchCriteria oneTimePinTypeSearchCriteria);
    }
}