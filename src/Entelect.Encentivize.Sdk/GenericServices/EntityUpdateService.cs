using System;
using System.Globalization;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityUpdateService<TInput, TOutput> : EntityService, IEntityUpdateService<TInput, TOutput> 
        where TInput : BaseInput
        where TOutput : class, new()
    {
        const string IdNotSetVerb = "update";

        public EntityUpdateService(IRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public virtual TOutput Update(int id, TInput input)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return DoUpdate(id.ToString(CultureInfo.InvariantCulture), input);
        }

        public virtual TOutput Update(long id, TInput input)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return DoUpdate(id.ToString(CultureInfo.InvariantCulture), input);
        }

        public virtual TOutput Update(Guid id, TInput input)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return DoUpdate(id.ToString(), input);
        }

        public TOutput Update(string customPath, TInput input)
        {
            return Update(input, new RestRequest(customPath));
        }

        protected virtual TOutput DoUpdate(string id, TInput input)
        {
            return Update(input, new RestRequest(string.Format("{0}/{1}", EntitySettings.EntityRoute, id)));
        }

        protected virtual TOutput Update(TInput input, RestRequest restRequest)
        {
            restRequest.Method = Method.PUT;
            restRequest.RequestFormat = DataFormat.Json;
            input.Validate();
            restRequest.AddBody(input);
            var response = RestClient.Execute<TOutput>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new UpdateFailedException(response);
            }
            return response.Data;
        }
    }
}