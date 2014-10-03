using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public abstract class PointsTransactionOutput
    {
        public long PointsTransactionsId { get; set; }
        public DateTime TransactionDateUtc { get; set; }
        public string PointsTransactionName { get; set; }
        public string PointsTransactionType { get; set; }
        public string Comment { get; set; }
        public decimal PointsValue { get; set; }
        public long? MemberId { get; set; }
        public long CreatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtc { get; set; }
        public decimal PointsBalance { get; set; }
    }
}