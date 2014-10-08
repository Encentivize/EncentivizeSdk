
namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class RetractedAchievementTransactionOutput : PointsTransactionOutput
    {
        public long AchievementTransactionId { get; set; }

        public string AdditionalInformation { get; set; }
    }
}