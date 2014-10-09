using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class BaseCreationService<TInput> : EntityService
        where TInput : BaseInput
    {
        public BaseCreationService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        protected static void PrepareCreateRequest(RestRequest restRequest, TInput input)
        {
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            input.Validate();
            restRequest.AddBody(input);
        }
    }
}