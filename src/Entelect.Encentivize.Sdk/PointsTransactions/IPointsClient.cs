namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public interface IPointsClient
    {
        PagedResult<PointsTransactionOutput> Get(PointsTransactionSearchCriteria pointsTransactionSearchCriteria);
        PagedResult<PointsTransactionOutput> GetPointsForMember(long memberId, PointsTransactionSearchCriteria pointsTransactionSearchCriteria);
        PagedResult<PointsTransactionOutput> GetPointsForMe(PointsTransactionSearchCriteria pointsTransactionSearchCriteria);
        AdHocTransactionOutput AddAdhocPoints(long memberId, AdHocPointsInput adhocInput);
        TransferPointsOutput TransferPoints(long fromMemberId, TransferPointsInput transferPointsInput);
    }
}