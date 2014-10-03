using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PointsTransferOutput
    {
        public long PointsTransferId { get; set; }
        public string Comment { get; set; }
        public DateTime DateOfTransferUtc { get; set; }
        public string PointsTransfered { get; set; }
        public long InitiatingUserId { get; set; }
        public long FromPointsTransactionId { get; set; }
        public long FromUserId { get; set; }
        public long ToPointsTransactionId { get; set; }
        public long ToUserId { get; set; }
    }
}