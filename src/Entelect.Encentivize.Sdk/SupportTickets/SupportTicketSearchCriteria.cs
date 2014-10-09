using System;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class SupportTicketSearchCriteria : BaseSearchCriteria
    {
        public long? SupportTicketId { get; set; }

        public long? SupportTicketCategoryId { get; set; }

        public long? SupportTicketTypeId { get; set; }

        public long? SupportTicketPriorityId { get; set; }

        public string Subject { get; set; }

        public string LatestComment { get; set; }

        public bool? IsResolved { get; set; }

        public string Tags { get; set; }

        public DateTime? DateRequestedFrom { get; set; }

        public DateTime? DateRequestedTo { get; set; }

        public long? RequestedById { get; set; }

        public DateTime? LastUpdatedFrom { get; set; }

        public DateTime? LastUpdatedTo { get; set; }

        public long? LastUpdatedById { get; set; }

        public long? SupportAgentId { get; set; }
    }
}
