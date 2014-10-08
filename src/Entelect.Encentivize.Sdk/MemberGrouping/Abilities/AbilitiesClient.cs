using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public class AbilitiesClient : IAbilitiesClient
    {
        private readonly IEntityRetrievalService<Ability> _entityRetrievalService;

        public AbilitiesClient(IEntityRetrievalService<Ability> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public AbilitiesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Ability", "Abilities", "Abilities");
            _entityRetrievalService = new EntityRetrievalService<Ability>(restClient, entitySettings);
        }

        public virtual Ability Get(long abilityId)
        {
            return _entityRetrievalService.GetById(abilityId);
        }

        public virtual PagedResult<Ability> Search(AbilitySearchCriteria abilitySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(abilitySearchCriteria);
        }

    }
}