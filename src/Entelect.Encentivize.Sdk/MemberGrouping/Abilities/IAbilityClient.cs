namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public interface IAbilityClient
    {
        AbilityOutput Get(long achievementCategoryId);
        PagedResult<AbilityOutput> Search(AbilitySearchCriteria achievementCategorySearchCriteria);
    }
}