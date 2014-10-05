using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityService
    {
        protected readonly IRestClient RestClient;
        protected readonly EntitySettings EntitySettings;

        public EntityService(IRestClient restClient, EntitySettings entitySettings)
        {
            RestClient = restClient;
            EntitySettings = entitySettings;
        }
    }
}