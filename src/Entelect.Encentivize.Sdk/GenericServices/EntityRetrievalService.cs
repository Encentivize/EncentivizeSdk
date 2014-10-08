﻿using System;
using System.Globalization;
using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityRetrievalService<TOutput> : EntityService, IEntityRetrievalService<TOutput> 
        where TOutput : class, new()
    {
        private readonly IEncentivizeRestClient _restClient;
        const string IdNotSetVerb = "retrieve";

        public EntityRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings)
            :base(restClient, entitySettings)
        {
            _restClient = restClient;
            QueryStringBuilder = new QueryStringBuilder(propertiesToExclude: new[] { "PageNumber", "PageSize" });
        }

        protected QueryStringBuilder QueryStringBuilder { get; set; }

        public virtual TOutput GetById(int id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual TOutput GetById(long id)
        {
            if (id <= 0)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString(CultureInfo.InvariantCulture));
        }

        public virtual TOutput GetById(Guid id)
        {
            if (id == null)
            {
                throw new IdNotSetException(EntitySettings.EntityNameSingular, IdNotSetVerb);
            }
            return GetById(id.ToString());
        }

        public virtual TOutput Get(string customPath)
        {
            return DoGet(new RestRequest(customPath));
        }

        public virtual PagedResult<TOutput> FindBySearchCriteria(BaseSearchCriteria searchCriteria)
        {
            var queryString = GetQueryString(searchCriteria);
            return DoFindBySearchCriteria(new RestRequest(string.Format("{0}?{1}", EntitySettings.EntityRoute, queryString)));
        }

        public PagedResult<TOutput> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria)
        {
            var queryString = GetQueryString(searchCriteria);
            return DoFindBySearchCriteria(new RestRequest(string.Format("{0}?{1}", customPath, queryString)));
        }

        protected virtual TOutput GetById(string id)
        {
            return DoGet(new RestRequest(string.Format("{0}/{1}", EntitySettings.EntityRoute, id)));
        }

        protected virtual TOutput DoGet(RestRequest restRequest)
        {
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
            var response = RestClient.Execute<TOutput>(restRequest);
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

        protected virtual PagedResult<TOutput> DoFindBySearchCriteria(RestRequest restRequest)
        {
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = Method.GET;
            var response = RestClient.Execute<PagedResult<TOutput>>(restRequest);
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
}