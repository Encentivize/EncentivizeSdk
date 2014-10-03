using System;
using System.Globalization;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityRetrievalService<TOutput> : EntityService, IEntityRetrievalService<TOutput> 
        where TOutput : class, new()
    {

        public EntityRetrievalService(IRestClient restClient, string entityRoute)
            :base(restClient,entityRoute)
        {
        }

        public virtual TOutput GetById(int id)
        {
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual TOutput GetById(long id)
        {
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual TOutput GetById(Guid id)
        {
            return GetById(id.ToString());
        }

        public virtual TOutput GetById(string id)
        {
            var request = new RestRequest(string.Format("{0}/{1}", EntityRoute, id), Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = RestClient.Execute<TOutput>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new DataRetrievalFailedException(response);
            return response.Data;
        }
    }
}