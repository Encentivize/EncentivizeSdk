using System;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Clients
{
    public class CrudClientBase<TInput, TOutput> : ReadOnlyClientBase<TOutput>, ICrudClientBase<TInput, TOutput> 
        where TInput : BaseInput
        where TOutput : class, new()
    {
        public CrudClientBase(EncentivizeSettings settings, string entityRoute)
            : base(settings, entityRoute)
        {
        }

        #region Update

        public virtual TOutput Update(int id, TInput input)
        {
            return Update(id.ToString(), input);
        }

        public virtual TOutput Update(long id, TInput input)
        {
            return Update(id.ToString(), input);
        }

        public virtual TOutput Update(Guid id, TInput input)
        {
            return Update(id.ToString(), input);
        }

        public virtual TOutput Update(string id, TInput input)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("{0}/{1}", EntityRoute, id), Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(input);
            var response = client.Execute<TOutput>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new UpdateFailedException(response);
            }
            return response.Data;
        }

        #endregion

        #region Create

        public TOutput Create(TInput input)
        {
            input.Validate();
            var client = GetClient();
            var request = new RestRequest(string.Format("{0}", EntityRoute), Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(input);
            var response = client.Execute<TOutput>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
            return response.Data;
        }

        #endregion

        #region Delete

        public virtual void Delete(int id)
        {
            Delete(id.ToString());
        }

        public virtual void Delete(long id)
        {
            Delete(id.ToString());
        }

        public virtual void Delete(Guid id)
        {
            Delete(id.ToString());
        }

        public virtual void Delete(string id)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("{0}/{1}", EntityRoute, id), Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new DeleteFailedException(response);
        }

        #endregion
    }
}