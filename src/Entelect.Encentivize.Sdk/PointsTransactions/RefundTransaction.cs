namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class RefundTransaction : PointsTransaction
    {
        public long RewardTransactionsId { get; set; }
        public int RefundTransactionStatusId { get; set; }
    }
}