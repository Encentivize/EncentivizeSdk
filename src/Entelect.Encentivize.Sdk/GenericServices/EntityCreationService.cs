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
            input.Validate();
            var request = new RestRequest(string.Format("{0}", EntitySettings.EntityRoute), Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(input);
            var response = RestClient.Execute<TOutput>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
            return response.Data;
        }
    }
}