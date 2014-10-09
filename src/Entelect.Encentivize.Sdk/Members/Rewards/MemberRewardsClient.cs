﻿using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.PointsTransactions;
using Entelect.Encentivize.Sdk.Rewards;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public class MemberRewardsClient : IMemberRewardsClient
    {
        private readonly IEncentivizeRestClient _restClient;
        private readonly IEntityRetrievalService<RewardTransaction> _memberRewardRetrievalService;
        private readonly IEntityCreationService<RedeemRewardInput, RewardTransaction> _memberRewardCreationService;
        private readonly IEntityDeletionService<RedeemRewardInput, RewardTransaction> _memberRewardDeletionService;
        private readonly IEntityRetrievalService<RewardStructure> _rewardRetrievalService;
        private readonly IEntityRetrievalService _dynamicEntityRetrievalService;

        public MemberRewardsClient(IEncentivizeRestClient restClient, 
            IEntityRetrievalService<RewardTransaction> memberRewardRetrievalService, 
            IEntityCreationService<RedeemRewardInput, RewardTransaction> memberRewardCreationService,
            IEntityDeletionService<RedeemRewardInput, RewardTransaction> memberRewardDeletionService, 
            IEntityRetrievalService<RewardStructure> rewardRetrievalService, 
            IEntityRetrievalService dynamicEntityRetrievalService)
        {
            _restClient = restClient;
            _memberRewardRetrievalService = memberRewardRetrievalService;
            _memberRewardCreationService = memberRewardCreationService;
            _memberRewardDeletionService = memberRewardDeletionService;
            _rewardRetrievalService = rewardRetrievalService;
            _dynamicEntityRetrievalService = dynamicEntityRetrievalService;
        }

        public MemberRewardsClient(IEncentivizeRestClient restClient)
        {
            _restClient = restClient;
            var memberRewardSettings = new EntitySettings("Member Reward", "Member Rewards", "MemberRewards");
            _memberRewardRetrievalService = new EntityRetrievalService<RewardTransaction>(restClient, memberRewardSettings);
            _memberRewardCreationService = new EntityCreationService<RedeemRewardInput, RewardTransaction>(restClient, memberRewardSettings);
            _memberRewardDeletionService = new EntityDeletionService<RedeemRewardInput, RewardTransaction>(restClient, memberRewardSettings);
            _dynamicEntityRetrievalService = new EntityRetrievalService(_restClient);
            /* todo rk move to own client ? */
            var rewardSettings = new EntitySettings("Reward", "Rewards", null);
            _rewardRetrievalService = new EntityRetrievalService<RewardStructure>(_restClient, rewardSettings);
        }

        public virtual PagedResult<RewardTransaction> Search(RewardTransactionSearchCriteria rewardSearchCriteria)
        {
            return _memberRewardRetrievalService.FindBySearchCriteria(rewardSearchCriteria);
        }

        public virtual PagedResult<RewardTransaction> MemberHistory(long memberId, RewardTransactionSearchCriteria rewardSearchCriteria)
        {
            return _memberRewardRetrievalService.FindBySearchCriteria(string.Format("members/{0}/rewards/", memberId), rewardSearchCriteria);
        }

        public virtual PagedResult<RewardStructure> GetAvailableRewardsForMember(long memberId, RewardSearchCriteria rewardSearchCriteria)
        {
            return _rewardRetrievalService.FindBySearchCriteria(string.Format("members/{0}/availableRewards", memberId), rewardSearchCriteria);
        }

        public virtual RewardTransaction RedeemReward(long memberId, RedeemRewardInput redeemRewardInput)
        {
            return _memberRewardCreationService.Create(string.Format("members/{0}/redeemReward/", memberId), redeemRewardInput);
        }

        public virtual RewardTransaction Get(long memberId, long rewardTransactionId)
        {
            return _memberRewardRetrievalService.Get(string.Format("members/{0}/rewards/{1}", memberId, rewardTransactionId));
        }

        public virtual void RefundReward(long memberId, long rewardTransactionId)
        {
            _memberRewardDeletionService.Delete(string.Format("members/{0}/rewards/{1}/", memberId, rewardTransactionId));
        }

        public virtual dynamic GetRewardAdditionalInformation(long memberId, long rewardTransactionId)
        {
            return _dynamicEntityRetrievalService.Get(string.Format("members/{0}/rewards/{1}/additionalInformation", memberId, rewardTransactionId));
        }

        public virtual dynamic UpdateRewardAdditionalInformation(long memberId, long rewardTransactionId, dynamic additionalInformation)
        {
            var request = new RestRequest(AdditionalInfoUrl(memberId, rewardTransactionId))
            {
                Method = Method.PUT,
                RequestFormat = DataFormat.Json
            };
            request.AddBody(additionalInformation);
            var response = _restClient.Execute<dynamic>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
            return response.Data;
        }

        private string AdditionalInfoUrl(long memberId, long rewardTransactionId)
        {
            return string.Format("members/{0}/rewards/{1}/additionalInformation", memberId, rewardTransactionId);
        }
    }
}