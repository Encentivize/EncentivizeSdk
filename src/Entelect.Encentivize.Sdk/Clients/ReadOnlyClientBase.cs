using System;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Clients
{
    public class ReadOnlyClientBase<TOutput> : ClientBase, IReadOnlyClientBase<TOutput> 
        where TOutput : class, new()
    {
        protected readonly string EntityRoute;

        public ReadOnlyClientBase(EncentivizeSettings settings, string entityRoute) 
            : base(settings)
        {
            EntityRoute = entityRoute;
        }

        #region Get

        public virtual TOutput GetById(int id)
        {
            return GetById(id.ToString());
        }

        public virtual TOutput GetById(long id)
        {
            return GetById(id.ToString());
        }

        public virtual TOutput GetById(Guid id)
        {
            return GetById(id.ToString());
        }

        public virtual TOutput GetById(string id)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("{0}/{1}", EntityRoute, id), Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<TOutput>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new DataRetrievalFailedException(response.Content);
            return response.Data;
        }

        #endregion
    }
}