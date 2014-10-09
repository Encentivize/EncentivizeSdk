using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public abstract class BaseRetrievalService : EntityService
    {
        protected BaseRetrievalService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
            QueryStringBuilder = new QueryStringBuilder(propertiesToExclude: new[] { "PageNumber", "PageSize" });
        }

        protected QueryStringBuilder QueryStringBuilder;

        protected const string IdNotSetVerb = "retrieve";

        protected static void SetupGetRequest(RestRequest restRequest)
        {
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
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