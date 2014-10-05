using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public class AbilitiesClient : IAbilitiesClient
    {
        private readonly IEntityRetrievalService<AbilityOutput> _entityRetrievalService;
        public AbilitiesClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("Ability", "Abilities", "Abilities");
            _entityRetrievalService = new EntityRetrievalService<AbilityOutput>(restClient, entitySettings);
        }

        public AbilityOutput Get(long abilityId)
        {
            return _entityRetrievalService.GetById(abilityId);
        }

        public PagedResult<AbilityOutput> Search(AbilitySearchCriteria abilitySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(abilitySearchCriteria);
        }

    }
}