using System;
using System.Globalization;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityUpdateService<TInput, TEntity> : EntityService, IEntityUpdateService<TInput, TEntity> 
        where TInput : BaseInput
        where TEntity : class, IEditableEntity<TInput>, new()
    {
        const string IdNotSetVerb = "update";

        public EntityUpdateService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public virtual TEntity Update(int id, TInput input)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return UpdateById(id.ToString(CultureInfo.InvariantCulture), input);
        }

        public virtual TEntity Update(long id, TInput input)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return UpdateById(id.ToString(CultureInfo.InvariantCulture), input);
        }

        public virtual TEntity Update(Guid id, TInput input)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return UpdateById(id.ToString(), input);
        }

        public TEntity Update(string customPath, TInput input)
        {
            return Update(input, new RestRequest(customPath));
        }

        public TEntity Update(TEntity entity)
        {
            return Update(entity.GetModificationUrl(), entity.ToInput());
        }

        protected virtual TEntity UpdateById(string id, TInput input)
        {
            return Update(input, new RestRequest(string.Format("{0}/{1}", EntitySettings.BaseRoute, id)));
        }

        protected virtual TEntity Update(TInput input, RestRequest restRequest)
        {
            restRequest.Method = Method.PUT;
            restRequest.RequestFormat = DataFormat.Json;
            input.Validate();
            restRequest.AddBody(input);
            var response = RestClient.Execute<TEntity>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new UpdateFailedException(response);
            }
            return response.Data;
        }
    }
}