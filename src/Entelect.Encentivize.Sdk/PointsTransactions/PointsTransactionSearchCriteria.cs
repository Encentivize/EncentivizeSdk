using System;

namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class PointsTransactionSearchCriteria : BaseSearchCriteria
    {
        public long? PointsCostingConversionId { get; set; }
        public long? UserId { get; set; }
        public int? PointsValue { get; set; }
        public string Comment { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtcFrom { get; set; }
        public DateTime? LastUpdatedDateUtcTo { get; set; }
        public long? UserAchievementId { get; set; }
        public string[] Types { get; set; }
        public int? MinimumPointsValue { get; set; }
        public int? MaximumPointsValue { get; set; }
    }
}
