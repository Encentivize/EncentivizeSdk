using Entelect.Encentivize.Sdk.PointsTransactions;

namespace Entelect.Encentivize.Sdk.Points
{
    public interface IPointsClient
    {
        AdHocTransactionOutput AddAdhocPoints(long memberId, AdHocPointsInput adhocInput);
    }
}