using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Abilities
{
    public class AbilityClient : IAbilityClient
    {
        private readonly IEntityRetrievalService<AbilityOutput> _entityRetrievalService;
        public AbilityClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("Ability", "Abilities", "Abilities");
            _entityRetrievalService = new EntityRetrievalService<AbilityOutput>(restClient, entitySettings);
        }

        public AbilityOutput Get(long achievementCategoryId)
        {
            return _entityRetrievalService.GetById(achievementCategoryId);
        }

        public PagedResult<AbilityOutput> Search(AbilitySearchCriteria achievementCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(achievementCategorySearchCriteria);
        }

    }
}