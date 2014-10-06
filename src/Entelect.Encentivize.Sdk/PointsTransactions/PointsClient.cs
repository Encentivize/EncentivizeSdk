using Entelect.Encentivize.Sdk.Clients;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.PointsTransactions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Points
{
    public class PointsClient : IPointsClient
    {
        private readonly IRestClient _restClient;

        public PointsClient(IRestClient restClient) 
        {
            _restClient = restClient;
        }

        public virtual AdHocTransactionOutput AddAdhocPoints(long memberId, AdHocPointsInput adhocInput)
        {
            var entityCreationService = new EntityCreationService<AdHocPointsInput, AdHocTransactionOutput>(_restClient, new EntitySettings("Ad Hoc Points", "Ad Hoc Points", "members/{memberId:long}/AdHocPoints"));
            return entityCreationService.Create(string.Format("members/{0}/AdHocPoints", memberId), adhocInput);
        }
    }
}