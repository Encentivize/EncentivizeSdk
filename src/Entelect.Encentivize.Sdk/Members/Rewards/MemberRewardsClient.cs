using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.PointsTransactions;
using Entelect.Encentivize.Sdk.Rewards;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public class MemberRewardsClient
    {
        private readonly IRestClient _restClient;
        private readonly IEntityUpdateService<RedeemRewardInput, RewardTransactionOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<RewardTransactionOutput> _entityRetrievalService;
        private readonly IEntityCreationService<RedeemRewardInput, RewardTransactionOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public MemberRewardsClient(IRestClient restClient)
        {
            _restClient = restClient;
            var entitySettings = new EntitySettings("Member Reward", "Member Rewards", "MemberRewards");
            _entityUpdateService = new EntityUpdateService<RedeemRewardInput, RewardTransactionOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<RewardTransactionOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<RedeemRewardInput, RewardTransactionOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual PagedResult<RewardTransactionOutput> Search(RewardTransactionSearchCriteria rewardSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(rewardSearchCriteria);
        }

        public virtual PagedResult<RewardTransactionOutput> MemberHistory(long memberId, RewardTransactionSearchCriteria rewardSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(string.Format("members/{0}/rewards/", memberId), rewardSearchCriteria);
        }

        public virtual PagedResult<RewardStructureOutput> GetAvailableRewardsForMember(long memberId, RewardSearchCriteria rewardSearchCriteria)
        {
            return new EntityRetrievalService<RewardStructureOutput>(_restClient, new EntitySettings("Reward", "Rewards", null))
                .FindBySearchCriteria(string.Format("members/{0}/availableRewards", memberId), rewardSearchCriteria);
        }

        public virtual RewardTransactionOutput RedeemReward(long memberId, RedeemRewardInput redeemRewardInput)
        {
            return _entityCreationService.Create(string.Format("members/{0}/redeemReward/", memberId), redeemRewardInput);
        }

        public virtual RewardTransactionOutput Get(long memberId, long rewardTransactionId)
        {
            return _entityRetrievalService.Get(string.Format("members/{0}/rewards/{1}", memberId, rewardTransactionId));
        }

        public virtual void RefundReward(long memberId, long rewardTransactionId)
        {
            _entityDeletionService.Delete(string.Format("members/{0}/rewards/{1}/", memberId, rewardTransactionId));
        }

        public virtual dynamic GetRewardAdditionalInformation(long memberId, long rewardTransactionId)
        {
            const string entityName = "Additional Information";
            return new EntityRetrievalService<dynamic>(_restClient, new EntitySettings(entityName, entityName, entityName))
                .Get(string.Format("members/{0}/rewards/{1}/additionalInformation", memberId, rewardTransactionId));
        }

        public virtual RewardTransactionOutput UpdateRewardAdditionalInformation(long memberId, long rewardTransactionId, dynamic additionalInformation)
        {
            return _entityUpdateService.Update(string.Format("members/{0}/rewards/{1}/additionalInformation", memberId, rewardTransactionId), additionalInformation);
        }

        
    }
}