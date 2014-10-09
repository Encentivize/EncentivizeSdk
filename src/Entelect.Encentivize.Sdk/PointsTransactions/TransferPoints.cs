using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class TransferPoints: IEditableEntity<TransferPointsInput>
    {
        public long PointsTransferId { get; set; }
        public string Comment { get; set; }
        public DateTime DateOfTransferUtc { get; set; }
        public decimal PointsTransfered { get; set; }
        public long InitiatingUserId { get; set; }
        public long FromPointsTransactionId { get; set; }
        public long FromUserId { get; set; }
        public long ToPointsTransactionId { get; set; }
        public long ToUserId { get; set; }
        public TransferPointsInput ToInput()
        {
            return new TransferPointsInput
            {
                Comment = Comment,
                PointsToTransfer = PointsTransfered,
                ToUserId = ToUserId
            };
        }

        public string GetModificationUrl()
        {
            throw new NotSupportedException("Points transfers can not be modified");
        }
    }
}