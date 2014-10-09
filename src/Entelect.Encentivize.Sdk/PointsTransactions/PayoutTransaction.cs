using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PayoutTransaction : PointsTransaction
    {
        public DateTime? DatePaidOut { get; set; }
        public long UserTerminationId { get; set; }
    }
}