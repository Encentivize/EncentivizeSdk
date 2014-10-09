namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class ToPointsTransferTransaction : PointsTransaction
    {
        public long PointsTransferId { get; set; }
        public long FromUserId { get; set; }
    }
}