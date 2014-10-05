namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public interface IAbilitiesClient
    {
        AbilityOutput Get(long abilityId);
        PagedResult<AbilityOutput> Search(AbilitySearchCriteria abilitySearchCriteria);
    }
}