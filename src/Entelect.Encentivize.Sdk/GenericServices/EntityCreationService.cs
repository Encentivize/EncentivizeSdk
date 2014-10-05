using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityCreationService<TInput, TOutput> : EntityService, IEntityCreationService<TInput, TOutput> 
        where TInput : BaseInput
        where TOutput : class, new()
    {
        public EntityCreationService(IRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public TOutput Create(TInput input)
        {
            return DoCreate(new RestRequest(string.Format("{0}", EntitySettings.EntityRoute)), input);
        }

        public TOutput Create(string customPath, TInput input)
        {
            return DoCreate(new RestRequest(customPath), input);
        }

        protected virtual TOutput DoCreate(RestRequest restRequest, TInput input)
        {
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            input.Validate();
            restRequest.AddBody(input);
            var response = RestClient.Execute<TOutput>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
            return response.Data;
        }
    }
}