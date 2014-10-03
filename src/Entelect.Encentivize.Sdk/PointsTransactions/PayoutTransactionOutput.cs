using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PayoutTransactionOutput : PointsTransactionOutput
    {
        public DateTime? DatePaidOut { get; set; }
        public long UserTerminationId { get; set; }
    }
}