namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class FromPointsTransferTransactionOutput : PointsTransactionOutput
    {
        public long PointsTransferId { get; set; }
        public long ToUserId { get; set; }
    }
}