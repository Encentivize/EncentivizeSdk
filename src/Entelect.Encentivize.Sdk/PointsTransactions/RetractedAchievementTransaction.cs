
namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class RetractedAchievementTransaction : PointsTransaction
    {
        public long AchievementTransactionId { get; set; }

        public string AdditionalInformation { get; set; }
    }
}