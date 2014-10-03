using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class RewardTransactionOutput : PointsTransactionOutput
    {
        public dynamic AdditionalInformation { get; set; }
        public long RewardId { get; set; }
        public int RewardsTransactionStatusId { get; set; }
        public int NumberOfRewards { get; set; }
        public long? ProductRequestId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateRedeemed { get; set; }
        public DateTime? DateSignOff { get; set; }
    }
}