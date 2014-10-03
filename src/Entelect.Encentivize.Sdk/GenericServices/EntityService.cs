using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityService
    {
        protected readonly IRestClient RestClient;
        protected readonly string EntityRoute;

        public EntityService(IRestClient restClient, string entityRoute)
        {
            RestClient = restClient;
            EntityRoute = entityRoute;
        } 
    }
}