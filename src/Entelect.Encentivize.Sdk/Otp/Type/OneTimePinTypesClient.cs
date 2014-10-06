using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Otp.Type
{
    public class OneTimePinTypesClient : IOneTimePinTypesClient
    {
        private readonly IEntityRetrievalService<OneTimePinTypeOutput> _entityRetrievalService;
        public OneTimePinTypesClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("One Time Pin Type", "One Time Pin Types", "OneTimePinTypes");
            _entityRetrievalService = new EntityRetrievalService<OneTimePinTypeOutput>(restClient, entitySettings);
        }

        public OneTimePinTypeOutput Get(long oneTimePinTypeId)
        {
            return _entityRetrievalService.GetById(oneTimePinTypeId);
        }

        public PagedResult<OneTimePinTypeOutput> Search(OneTimePinTypeSearchCriteria oneTimePinTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(oneTimePinTypeSearchCriteria);
        }

    }
}