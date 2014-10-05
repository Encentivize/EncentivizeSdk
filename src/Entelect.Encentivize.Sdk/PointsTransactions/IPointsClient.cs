using Entelect.Encentivize.Sdk.PointsTransactions;

namespace Entelect.Encentivize.Sdk.Points
{
    public interface IPointsClient
    {
        void AddAdhocPoints(long memberId, AdHocPointsInput adhocInput);
    }
}