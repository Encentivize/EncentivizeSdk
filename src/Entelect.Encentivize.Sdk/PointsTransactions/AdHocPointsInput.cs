using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class AdHocPointsInput : BaseInput
    {
        [Required]
        public decimal PointsToAdd { get; set; }

        public string DisplayComment { get; set; }

        public dynamic AdditionalInformation { get; set; }
    }
}