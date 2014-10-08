using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public class AbilitiesClient : IAbilitiesClient
    {
        private readonly IEntityRetrievalService<AbilityOutput> _entityRetrievalService;
        public AbilitiesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Ability", "Abilities", "Abilities");
            _entityRetrievalService = new EntityRetrievalService<AbilityOutput>(restClient, entitySettings);
        }

        public virtual AbilityOutput Get(long abilityId)
        {
            return _entityRetrievalService.GetById(abilityId);
        }

        public virtual PagedResult<AbilityOutput> Search(AbilitySearchCriteria abilitySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(abilitySearchCriteria);
        }

    }
}