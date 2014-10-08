using System;
using System.Globalization;
using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityRetrievalService<TEntity> : EntityService, IEntityRetrievalService<TEntity> 
        where TEntity : class, IEntity, new()
    {
        const string IdNotSetVerb = "retrieve";

        public EntityRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings)
            :base(restClient, entitySettings)
        {
            QueryStringBuilder = new QueryStringBuilder(propertiesToExclude: new[] { "PageNumber", "PageSize" });
        }

        protected QueryStringBuilder QueryStringBuilder { get; set; }

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
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
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
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = Method.GET;
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

        protected virtual string GetQueryString(BaseSearchCriteria searchCriteria)
        {
            var queryString = QueryStringBuilder.ToQueryString(searchCriteria);
            if (!string.IsNullOrWhiteSpace(queryString))
            {
                queryString = string.Format("{0}&{1}", queryString, GetPagingQueryString(searchCriteria));
            }
            else
            {
                queryString = GetPagingQueryString(searchCriteria);
            }
            return queryString;
        }

        protected virtual string GetPagingQueryString(BaseSearchCriteria searchCriteria)
        {
            return string.Format("$page={0}&$pageSize={1}", searchCriteria.PageNumber, searchCriteria.PageSize);
        }
    }

    public class EntityRetrievalService : EntityService, IEntityRetrievalService
    {
        public EntityRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public dynamic Get(string customPath)
        {
            throw new NotImplementedException();
        }

        public PagedResult<dynamic> FindBySearchCriteria(BaseSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public PagedResult<dynamic> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }
    }
}