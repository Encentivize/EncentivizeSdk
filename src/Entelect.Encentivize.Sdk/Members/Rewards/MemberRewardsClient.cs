using System.Net;
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
        private readonly IEntityRetrievalService<RewardTransactionOutput> _memberRewardRetrievalService;
        private readonly IEntityCreationService<RedeemRewardInput, RewardTransactionOutput> _memberRewardCreationService;
        private readonly IEntityDeletionService<RedeemRewardInput, RewardTransactionOutput> _memberRewardDeletionService;
        private readonly IEntityRetrievalService<RewardStructureOutput> _rewardRetrievalService;
        private readonly IEntityRetrievalService _dynamicEntityRetrievalService;

        public MemberRewardsClient(IEncentivizeRestClient restClient, 
            IEntityRetrievalService<RewardTransactionOutput> memberRewardRetrievalService, 
            IEntityCreationService<RedeemRewardInput, RewardTransactionOutput> memberRewardCreationService,
            IEntityDeletionService<RedeemRewardInput, RewardTransactionOutput> memberRewardDeletionService, 
            IEntityRetrievalService<RewardStructureOutput> rewardRetrievalService, 
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
            _memberRewardRetrievalService = new EntityRetrievalService<RewardTransactionOutput>(restClient, memberRewardSettings);
            _memberRewardCreationService = new EntityCreationService<RedeemRewardInput, RewardTransactionOutput>(restClient, memberRewardSettings);
            _memberRewardDeletionService = new EntityDeletionService<RedeemRewardInput, RewardTransactionOutput>(restClient, memberRewardSettings);
            var additionalInformationEntitySettings = new EntitySettings("Additional Information", "Additional Information",
                "members/{memberId:long}/rewards/{rewardTransactionId:long}/additionalInformation");
            _dynamicEntityRetrievalService = new EntityRetrievalService(_restClient, additionalInformationEntitySettings);
            /* todo rk move to own client ? */
            var rewardSettings = new EntitySettings("Reward", "Rewards", null);
            _rewardRetrievalService = new EntityRetrievalService<RewardStructureOutput>(_restClient, rewardSettings);
        }

        public virtual PagedResult<RewardTransactionOutput> Search(RewardTransactionSearchCriteria rewardSearchCriteria)
        {
            return _memberRewardRetrievalService.FindBySearchCriteria(rewardSearchCriteria);
        }

        public virtual PagedResult<RewardTransactionOutput> MemberHistory(long memberId, RewardTransactionSearchCriteria rewardSearchCriteria)
        {
            return _memberRewardRetrievalService.FindBySearchCriteria(string.Format("members/{0}/rewards/", memberId), rewardSearchCriteria);
        }

        public virtual PagedResult<RewardStructureOutput> GetAvailableRewardsForMember(long memberId, RewardSearchCriteria rewardSearchCriteria)
        {
            return _rewardRetrievalService.FindBySearchCriteria(string.Format("members/{0}/availableRewards", memberId), rewardSearchCriteria);
        }

        public virtual RewardTransactionOutput RedeemReward(long memberId, RedeemRewardInput redeemRewardInput)
        {
            return _memberRewardCreationService.Create(string.Format("members/{0}/redeemReward/", memberId), redeemRewardInput);
        }

        public virtual RewardTransactionOutput Get(long memberId, long rewardTransactionId)
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