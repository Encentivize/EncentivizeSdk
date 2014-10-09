using System;

namespace Entelect.Encentivize.Sdk.Rewards
{
    public class RewardSearchCriteria : BaseSearchCriteria
    {
        public decimal? PointsLower { get; set; }
        public decimal? PointsUpper { get; set; }
        public string Keyword { get; set; }
        public long? RewardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DefaultPointsCost { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public int? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtcFrom { get; set; }
        public DateTime? LastUpdatedDateUtcTo { get; set; }
        public Decimal? RandValue { get; set; }
        public int? RewardRedemptionMechanismId { get; set; }
        public long? PointsTransactionsId { get; set; }
        public long? CategoryId { get; set; }
        public long? StructureId { get; set; }
        public bool? IsKudosOnlyReward { get; set; }
        public bool? IncludeKudosOnlyRewards { get; set; }
        public bool IsSearchStore { get; set; }
        public bool? TermsAndConditionsMustBeAccepted { get; set; }
    }
}
