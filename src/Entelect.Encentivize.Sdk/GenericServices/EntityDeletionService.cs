using System;
using System.Globalization;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityDeletionService: EntityService, IEntityDeletionService
    {
        public EntityDeletionService(IRestClient restClient, EntitySettings entitySettings) 
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
            Delete(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual void Delete(long id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            Delete(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual void Delete(Guid id)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            Delete(id.ToString());
        }

        public virtual void Delete(string id)
        {
            var request = new RestRequest(string.Format("{0}/{1}", EntitySettings.EntityRoute, id), Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };
            var response = RestClient.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new DeleteFailedException(response);
            }
        }
    }
}