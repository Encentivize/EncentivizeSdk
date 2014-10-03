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
        public EntityUpdateService(IRestClient restClient, string entityRoute) 
            : base(restClient, entityRoute)
        {
        }

        public virtual TOutput Update(int id, TInput input)
        {
            return Update(id.ToString(CultureInfo.InvariantCulture), input);
        }

        public virtual TOutput Update(long id, TInput input)
        {
            return Update(id.ToString(CultureInfo.InvariantCulture), input);
        }

        public virtual TOutput Update(Guid id, TInput input)
        {
            return Update(id.ToString(), input);
        }

        public virtual TOutput Update(string id, TInput input)
        {
            input.Validate();
            var request = new RestRequest(string.Format("{0}/{1}", EntityRoute, id), Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(input);
            var response = RestClient.Execute<TOutput>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new UpdateFailedException(response);
            }
            return response.Data;
        }
    }
}