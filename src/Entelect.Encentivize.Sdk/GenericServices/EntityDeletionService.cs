using System;
using System.Globalization;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityDeletionService: EntityService, IEntityDeletionService
    {
        public EntityDeletionService(IRestClient restClient, string entityRoute) 
            : base(restClient, entityRoute)
        {
        }

        public virtual void Delete(int id)
        {
            Delete(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual void Delete(long id)
        {
            Delete(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual void Delete(Guid id)
        {
            Delete(id.ToString());
        }

        public virtual void Delete(string id)
        {
            var request = new RestRequest(string.Format("{0}/{1}", EntityRoute, id), Method.DELETE)
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