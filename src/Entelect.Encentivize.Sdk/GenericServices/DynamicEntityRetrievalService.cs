using System;
using System.Globalization;
using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class DynamicEntityRetrievalService : EntityService, IDynamicEntityRetrievalService
    {
        const string IdNotSetVerb = "retrieve";

        public DynamicEntityRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public dynamic GetById(int id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public dynamic GetById(long id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public dynamic GetById(Guid id)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString());
        }

        public dynamic Get(string customPath)
        {
            return DoGet(new RestRequest(customPath));
        }


        protected virtual dynamic GetById(string id)
        {
            return DoGet(new RestRequest(string.Format("{0}/{1}", EntitySettings.EntityRoute, id)));
        }

        protected virtual dynamic DoGet(RestRequest restRequest)
        {
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
            var response = RestClient.Execute<dynamic>(restRequest);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw new DataRetrievalFailedException(response);
            }
            return response.Data;
        }
    }
}