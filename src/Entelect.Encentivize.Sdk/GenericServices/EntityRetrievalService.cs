using System;
using System.Globalization;
using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityRetrievalService<TEntity> : BaseRetrievalService, IEntityRetrievalService<TEntity> 
        where TEntity : class, IEntity, new()
    {

        public EntityRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings)
            :base(restClient, entitySettings)
        {
        }

        public virtual TEntity GetById(int id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual TEntity GetById(long id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual TEntity GetById(Guid id)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString());
        }

        public virtual TEntity Get(string customPath)
        {
            return DoGet(new RestRequest(customPath));
        }

        public virtual PagedResult<TEntity> FindBySearchCriteria(BaseSearchCriteria searchCriteria)
        {
            var queryString = GetQueryString(searchCriteria);
            return DoFindBySearchCriteria(new RestRequest(string.Format("{0}?{1}", EntitySettings.BaseRoute, queryString)));
        }

        public PagedResult<TEntity> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria)
        {
            var queryString = GetQueryString(searchCriteria);
            return DoFindBySearchCriteria(new RestRequest(string.Format("{0}?{1}", customPath, queryString)));
        }

        protected virtual TEntity GetById(string id)
        {
            return DoGet(new RestRequest(string.Format("{0}/{1}", EntitySettings.BaseRoute, id)));
        }

        protected virtual TEntity DoGet(RestRequest restRequest)
        {
            SetupGetRequest(restRequest);
            var response = RestClient.Execute<TEntity>(restRequest);
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

        protected virtual PagedResult<TEntity> DoFindBySearchCriteria(RestRequest restRequest)
        {
            SetupGetRequest(restRequest);
            var response = RestClient.Execute<PagedResult<TEntity>>(restRequest);
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

    public class EntityRetrievalService : BaseRetrievalService, IEntityRetrievalService
    {
        public EntityRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public dynamic Get(string customPath)
        {
            var restRequest = new RestRequest(customPath);
            SetupGetRequest(restRequest);
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

        public PagedResult<dynamic> FindBySearchCriteria(BaseSearchCriteria searchCriteria)
        {
            var queryString = GetQueryString(searchCriteria);
            return DoFindBySearchCriteria(new RestRequest(string.Format("{0}?{1}", EntitySettings.BaseRoute, queryString)));
        }

        public PagedResult<dynamic> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria)
        {
            var queryString = GetQueryString(searchCriteria);
            return DoFindBySearchCriteria(new RestRequest(string.Format("{0}?{1}", customPath, queryString)));
        }

        protected virtual PagedResult<dynamic> DoFindBySearchCriteria(RestRequest restRequest)
        {
            SetupGetRequest(restRequest);
            var response = RestClient.Execute<PagedResult<dynamic>>(restRequest);
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