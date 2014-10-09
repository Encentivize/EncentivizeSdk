namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class AdHocTransaction : PointsTransaction, IEntity
    {
        public dynamic AdditionalInformation { get; set; }
    }
}