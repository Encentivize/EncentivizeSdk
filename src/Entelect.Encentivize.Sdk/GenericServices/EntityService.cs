namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityService
    {
        protected readonly IEncentivizeRestClient RestClient;
        protected readonly EntitySettings EntitySettings;

        public EntityService(IEncentivizeRestClient restClient, EntitySettings entitySettings)
        {
            RestClient = restClient;
            EntitySettings = entitySettings;
        }
    }
}