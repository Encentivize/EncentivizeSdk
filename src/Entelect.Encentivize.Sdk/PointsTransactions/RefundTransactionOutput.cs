namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class RefundTransactionOutput : PointsTransactionOutput
    {
        public long RewardTransactionsId { get; set; }
        public int RefundTransactionStatusId { get; set; }
    }
}