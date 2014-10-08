using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Type
{
    public class OneTimePinTypesClient : IOneTimePinTypesClient
    {
        private readonly IEntityRetrievalService<OneTimePinTypeOutput> _entityRetrievalService;

        public OneTimePinTypesClient(IEntityRetrievalService<OneTimePinTypeOutput> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public OneTimePinTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("One Time Pin Type", "One Time Pin Types", "OneTimePinTypes");
            _entityRetrievalService = new EntityRetrievalService<OneTimePinTypeOutput>(restClient, entitySettings);
        }

        public virtual OneTimePinTypeOutput Get(long oneTimePinTypeId)
        {
            return _entityRetrievalService.GetById(oneTimePinTypeId);
        }

        public virtual PagedResult<OneTimePinTypeOutput> Search(OneTimePinTypeSearchCriteria oneTimePinTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(oneTimePinTypeSearchCriteria);
        }

    }
}