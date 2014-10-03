using System;
using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PointsTransactionInput
    {
        public long ProgramId { get; set; }
        public string ProgramName { get; set; }
        public long StructureId { get; set; }
        public string StructureIdDisplayValue { get; set; }
        public long PointsTransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PointsTransactionName { get; set; }
        public string PointsTransactionType { get; set; }
        public string Comment { get; set; }
        public decimal PointsValue { get; set; }

        [DataType("ImageUrl")]
        public string PointsIconUrl { get; set; }
        
    }
}