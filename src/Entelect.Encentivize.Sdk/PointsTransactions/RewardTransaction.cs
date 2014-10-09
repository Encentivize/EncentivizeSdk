using System;
using Entelect.Encentivize.Sdk.Members.Rewards;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class RewardTransaction : PointsTransaction, IEditableEntity<RedeemRewardInput>
    {
        public dynamic AdditionalInformation { get; set; }
        public long RewardId { get; set; }
        public int RewardsTransactionStatusId { get; set; }
        public int NumberOfRewards { get; set; }
        public long? ProductRequestId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateRedeemed { get; set; }
        public DateTime? DateSignOff { get; set; }
        public RedeemRewardInput ToEditInput()
        {
            return new RedeemRewardInput
            {
                AdditionalInformation = AdditionalInformation,
                OverriddenPoints = PointsValue,
                Quantity = NumberOfRewards,
                RewardId = RewardId
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("members/{0}/rewards/{1}/", MemberId, PointsTransactionsId);
        }
    }
}