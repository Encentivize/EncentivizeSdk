using System;
using System.Collections.Generic;
using Entelect.Encentivize.Sdk.GenericServices;
using Newtonsoft.Json;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PointsClient : IPointsClient
    {
        private readonly IEntityRetrievalService _entityRetrievalService;
        private readonly IEntityCreationService<AdHocPointsInput, AdHocTransaction> _adHocCreationService;
        private readonly IEntityCreationService<TransferPointsInput, TransferPoints> _transferCreationService;

        public PointsClient(IEntityRetrievalService entityRetrievalService, 
            IEntityCreationService<AdHocPointsInput, AdHocTransaction> adHocCreationService, 
            IEntityCreationService<TransferPointsInput, TransferPoints> transferCreationService)
        {
            _entityRetrievalService = entityRetrievalService;
            _adHocCreationService = adHocCreationService;
            _transferCreationService = transferCreationService;
        }

        public PointsClient(IEncentivizeRestClient restClient) 
        {
            _entityRetrievalService = new EntityRetrievalService(restClient);
            var adHocSettings = new EntitySettings("Ad Hoc Points", "Ad Hoc Points", "members/{memberId:long}/AdHocPoints");
            _adHocCreationService = new EntityCreationService<AdHocPointsInput, AdHocTransaction>(restClient, adHocSettings);
            var transferSettings = new EntitySettings("Transfer Points", "Transfer Points", "members/{fromMemberId:long}/TransferPoints");
            _transferCreationService = new EntityCreationService<TransferPointsInput, TransferPoints>(restClient, transferSettings);
        }

        public virtual PagedResult<PointsTransaction> Get(PointsTransactionSearchCriteria pointsTransactionSearchCriteria)
        {
            var result = _entityRetrievalService.FindBySearchCriteria("pointsTransactions", pointsTransactionSearchCriteria);
            return Map(result);
        }

        public virtual PagedResult<PointsTransaction> GetPointsForMember(long memberId, PointsTransactionSearchCriteria pointsTransactionSearchCriteria)
        {
            var result = _entityRetrievalService.FindBySearchCriteria(string.Format("members/{0}/pointsTransactions",memberId), pointsTransactionSearchCriteria);
            return Map(result);
        }

        public virtual PagedResult<PointsTransaction> GetPointsForMe(PointsTransactionSearchCriteria pointsTransactionSearchCriteria)
        {
            var result = _entityRetrievalService.FindBySearchCriteria("members/me/pointsTransactions", pointsTransactionSearchCriteria);
            return Map(result);
        }

        public virtual AdHocTransaction AddAdhocPoints(long memberId, AdHocPointsInput adhocInput)
        {
            return _adHocCreationService.Create(string.Format("members/{0}/AdHocPoints", memberId), adhocInput);
        }

        public virtual TransferPoints TransferPoints(long fromMemberId, TransferPointsInput transferPointsInput)
        {
            return _transferCreationService.Create(string.Format("members/{0}/TransferPoints", fromMemberId), transferPointsInput);
        }

        protected virtual PagedResult<PointsTransaction> Map(PagedResult<dynamic> result)
        {
            var mappedResult = new PagedResult<PointsTransaction>(result);
            foreach (var item in result.Data)
            {
                Type type = NameToTypeMapping[item.pointsTransactionType.ToString()];
                var deserialisedObject = JsonConvert.DeserializeObject(item.ToString(), type);
                var pointsTransactionOutput = (PointsTransaction)deserialisedObject;
                mappedResult.Data.Add(pointsTransactionOutput);
            }
            return mappedResult;
        }

        protected virtual Dictionary<string, Type> NameToTypeMapping
        {
            get
            {
                return new Dictionary<string, Type>
                {
                    {"AdHoc", typeof (AdHocTransaction)},
                    {"FromPointsTransfer", typeof (FromPointsTransferTransaction)},
                    {"ToPointsTransfer", typeof (ToPointsTransferTransaction)},
                    {"LostPoints", typeof (LostPointsTransaction)},
                    {"Payout", typeof (PayoutTransaction)},
                    {"Refund", typeof (RefundTransaction)},
                    {"Reward", typeof (RewardTransaction)},
                    {"Points", typeof (PointsTransaction)},
                    {"Achievement", typeof (AchievementTransaction)},
                    {"RetractedAchievement", typeof (RetractedAchievementTransaction)}
                };
            }
        }
    }
}