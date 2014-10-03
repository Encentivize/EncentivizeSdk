namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class ToPointsTransferTransactionOutput : PointsTransactionOutput
    {
        public long PointsTransferId { get; set; }
        public long FromUserId { get; set; }
    }
}