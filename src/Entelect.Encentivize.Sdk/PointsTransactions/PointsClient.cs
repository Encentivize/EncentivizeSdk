using System;
using System.Collections.Generic;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.Points;
using Newtonsoft.Json;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PointsClient : IPointsClient
    {
        private readonly IEncentivizeRestClient _restClient;
        private EntityRetrievalService<object> _entityRetrievalService;

        public PointsClient(IEncentivizeRestClient restClient) 
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

        protected virtual PagedResult<PointsTransactionOutput> Map(PagedResult<dynamic> result)
        {
            var mappedResult = new PagedResult<PointsTransactionOutput>(result);
            foreach (var itemm in result.Data)
            {
                Type type = NameToTypeMapping[itemm.pointsTransactionType.ToString()];
                var deserialisedObject = JsonConvert.DeserializeObject(itemm.ToString(), type);
                var pointsTransactionOutput = (PointsTransactionOutput)deserialisedObject;
                mappedResult.Data.Add(pointsTransactionOutput);
            }
            return mappedResult;
        }

        private static Dictionary<string, Type> NameToTypeMapping
        {
            get
            {
                return new Dictionary<string, Type>
                {
                    {"AdHoc", typeof (AdHocTransactionOutput)},
                    {"FromPointsTransfer", typeof (FromPointsTransferTransactionOutput)},
                    {"ToPointsTransfer", typeof (ToPointsTransferTransactionOutput)},
                    {"LostPoints", typeof (LostPointsTransactionOutput)},
                    {"Payout", typeof (PayoutTransactionOutput)},
                    {"Refund", typeof (RefundTransactionOutput)},
                    {"Reward", typeof (RewardTransactionOutput)},
                    {"Points", typeof (PointsTransactionOutput)},
                    {"Achievement", typeof (AchievementTransactionOutput)},
                    {"RetractedAchievement", typeof (RetractedAchievementTransactionOutput)}
                };
            }
        }
    }
}