namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class TransferPointsInput
    {
        public long ToUserId { get; set; }

        public decimal PointsToTransfer { get; set; }

        public string Comment { get; set; }
    }
}