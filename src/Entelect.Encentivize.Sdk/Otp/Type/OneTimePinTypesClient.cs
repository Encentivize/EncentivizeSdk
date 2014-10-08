using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Type
{
    public class OneTimePinTypesClient : IOneTimePinTypesClient
    {
        private readonly IEntityRetrievalService<OneTimePinType> _entityRetrievalService;

        public OneTimePinTypesClient(IEntityRetrievalService<OneTimePinType> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public OneTimePinTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("One Time Pin Type", "One Time Pin Types", "OneTimePinTypes");
            _entityRetrievalService = new EntityRetrievalService<OneTimePinType>(restClient, entitySettings);
        }

        public virtual OneTimePinType Get(long oneTimePinTypeId)
        {
            return _entityRetrievalService.GetById(oneTimePinTypeId);
        }

        public virtual PagedResult<OneTimePinType> Search(OneTimePinTypeSearchCriteria oneTimePinTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(oneTimePinTypeSearchCriteria);
        }

    }
}