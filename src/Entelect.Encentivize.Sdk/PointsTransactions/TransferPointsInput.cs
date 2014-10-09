using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class TransferPointsInput : BaseInput
    {
        [Required]
        public long ToUserId { get; set; }

        [Required]
        public decimal PointsToTransfer { get; set; }

        public string Comment { get; set; }
    }
}