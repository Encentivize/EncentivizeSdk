namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public interface IAbilitiesClient
    {
        Ability Get(long abilityId);
        PagedResult<Ability> Search(AbilitySearchCriteria abilitySearchCriteria);
    }
}