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
        private EntityRetrievalService<object> _entityRetrievalService;

        public PointsClient(IRestClient restClient) 
        {
            _restClient = restClient;
            _entityRetrievalService = new EntityRetrievalService<object>(_restClient, new EntitySettings("Points Transaction", "Points Transactions", "PointsTransactions"));
        }

        public virtual PagedResult<PointsTransactionOutput> Get(PointsTransactionSearchCriteria pointsTransactionSearchCriteria)
        {
            var result = _entityRetrievalService.FindBySearchCriteria(pointsTransactionSearchCriteria);
            return Map(result);
        }

        public virtual PagedResult<PointsTransactionOutput> GetPointsForMember(long memberId, PointsTransactionSearchCriteria pointsTransactionSearchCriteria)
        {
            var result = _entityRetrievalService.FindBySearchCriteria(string.Format("members/{0}/pointsTransactions",memberId), pointsTransactionSearchCriteria);
            return Map(result);
        }

        public virtual PagedResult<PointsTransactionOutput> GetPointsForMe(PointsTransactionSearchCriteria pointsTransactionSearchCriteria)
        {
            var result = _entityRetrievalService.FindBySearchCriteria("members/me/pointsTransactions", pointsTransactionSearchCriteria);
            return Map(result);
        }

        public virtual AdHocTransactionOutput AddAdhocPoints(long memberId, AdHocPointsInput adhocInput)
        {
            var entityCreationService = new EntityCreationService<AdHocPointsInput, AdHocTransactionOutput>(_restClient, new EntitySettings("Ad Hoc Points", "Ad Hoc Points", "members/{memberId:long}/AdHocPoints"));
            return entityCreationService.Create(string.Format("members/{0}/AdHocPoints", memberId), adhocInput);
        }

        public virtual TransferPointsOutput TransferPoints(long fromMemberId, TransferPointsInput transferPointsInput)
        {
            var entityCreationService = new EntityCreationService<TransferPointsInput, TransferPointsOutput>(_restClient, new EntitySettings("Transfer Points", "Transfer Points", "members/{fromMemberId:long}/TransferPoints"));
            return entityCreationService.Create(string.Format("members/{0}/TransferPoints", fromMemberId), transferPointsInput);
        }

        protected virtual PagedResult<PointsTransactionOutput> Map(PagedResult<object> result)
        {
            /* todo rk, this whole method is shit and might not work, test and find a better way*/
            var mappedResult = new PagedResult<PointsTransactionOutput>();
            foreach (var item in result.Data)
            {
                var achievement = item as AchievementTransactionOutput;
                if (achievement != null)
                {
                    mappedResult.Data.Add(achievement);
                }
                var adHocTransactionOutput = item as AdHocTransactionOutput;
                if (adHocTransactionOutput != null)
                {
                    mappedResult.Data.Add(adHocTransactionOutput);
                }
                var fromPointsTransferTransactionOutput = item as FromPointsTransferTransactionOutput;
                if (fromPointsTransferTransactionOutput != null)
                {
                    mappedResult.Data.Add(fromPointsTransferTransactionOutput);
                }
                var lostPointsTransactionOutput = item as LostPointsTransactionOutput;
                if (lostPointsTransactionOutput != null)
                {
                    mappedResult.Data.Add(lostPointsTransactionOutput);
                }
                var payoutTransactionOutput = item as PayoutTransactionOutput;
                if (payoutTransactionOutput != null)
                {
                    mappedResult.Data.Add(payoutTransactionOutput);
                }
                var refundTransactionOutput = item as RefundTransactionOutput;
                if (refundTransactionOutput != null)
                {
                    mappedResult.Data.Add(refundTransactionOutput);
                }
                var rewardTransactionOutput = item as RewardTransactionOutput;
                if (rewardTransactionOutput != null)
                {
                    mappedResult.Data.Add(rewardTransactionOutput);
                }
                var toPointsTransferTransactionOutput = item as ToPointsTransferTransactionOutput;
                if (toPointsTransferTransactionOutput != null)
                {
                    mappedResult.Data.Add(toPointsTransferTransactionOutput);
                }
            }
            return mappedResult;
        }
    }
}