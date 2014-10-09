namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public interface IPointsClient
    {
        PagedResult<PointsTransaction> Get(PointsTransactionSearchCriteria pointsTransactionSearchCriteria);
        PagedResult<PointsTransaction> GetPointsForMember(long memberId, PointsTransactionSearchCriteria pointsTransactionSearchCriteria);
        PagedResult<PointsTransaction> GetPointsForMe(PointsTransactionSearchCriteria pointsTransactionSearchCriteria);
        AdHocTransaction AddAdhocPoints(long memberId, AdHocPointsInput adhocInput);
        TransferPoints TransferPoints(long fromMemberId, TransferPointsInput transferPointsInput);
    }
}