using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class BaseCreationService : EntityService
    {
        public BaseCreationService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        protected static void PrepareCreateRequest(RestRequest restRequest, object input)
        {
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(input);
        }
    }
}