using System;
using System.Globalization;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityDeletionService: EntityService, IEntityDeletionService
    {
        public EntityDeletionService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        const string IdNotSetVerb = "delete";

        public virtual void Delete(int id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            DeleteById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual void Delete(long id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            DeleteById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual void Delete(Guid id)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            DeleteById(id.ToString());
        }

        public void Delete(string customPath)
        {
            DoDelete(new RestRequest(customPath));
        }

        protected virtual void DeleteById(string id)
        {
            DoDelete(new RestRequest(string.Format("{0}/{1}", EntitySettings.EntityRoute, id)));
        }

        protected virtual void DoDelete(RestRequest restRequest)
        {
            restRequest.Method = Method.DELETE;
            restRequest.RequestFormat = DataFormat.Json;
            var response = RestClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new DeleteFailedException(response);
            }
        }
    }
}