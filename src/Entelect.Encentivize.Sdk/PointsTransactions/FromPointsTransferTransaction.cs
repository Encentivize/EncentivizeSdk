namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class FromPointsTransferTransaction : PointsTransaction
    {
        public long PointsTransferId { get; set; }
        public long ToUserId { get; set; }
    }
}