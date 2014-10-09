using System;

namespace Entelect.Encentivize.Sdk.Members.Rewards
{
    public class RewardTransactionSearchCriteria : BaseSearchCriteria
    {
        public long? MemberId { get; set; }
        public long? RewardId { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public DateTime? LastUpdatedDateUtcFrom { get; set; }
        public DateTime? LastUpdatedDateUtcTo { get; set; }
        public int? RewardsTransactionStatusId { get; set; }
    }
}
