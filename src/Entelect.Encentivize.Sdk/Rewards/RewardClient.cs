using Entelect.Encentivize.Sdk.Clients;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Rewards
{
    public class RewardClient : ClientBase, IRewardClient
    {
        public RewardClient(EncentivizeSettings settings) 
            : base(settings)
        {
        }

        public PagedResult<Reward> GetAvailableRewardsForMember(long memberId)
        {
            var client = GetClient();
            var request = new RestRequest("members/" + memberId + "/availableRewards", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Reward>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new DataRetrievalFailedException(response.Content);
            return response.Data;
        }

        public void RedeemReward(long memberId, long rewardId, int rewardCount)
        {
            var client = GetClient();
            var request = new RestRequest("members/" + memberId + "/redeemReward", Method.POST);
            request.RequestFormat = DataFormat.Json;
            var rewardInput = new RedeemRewardInput
            {
                Quantity = rewardCount,
                RewardId = rewardId
            };

            request.AddBody(rewardInput);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);

        }
    }
}