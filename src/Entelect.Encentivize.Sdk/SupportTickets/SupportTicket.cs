using System;
using System.Collections.Generic;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class SupportTicket : IEditableEntity<EditSupportTicketInput>, IEditableEntity<SupportTicketInput>
    {
        public long SupportTicketId { get; set; }
        public long SupportTicketTypeId { get; set; }
        public long SupportTicketCategoryId { get; set; }
        public string Subject { get; set; }
        public bool IsResolved { get; set; }
        public string LatestComment { get; set; }
        public List<CommentOutput> Comments { get; set; }
        public List<long> SupportAgentIds { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public EditSupportTicketInput ToInput()
        {
            throw new NotImplementedException();
        }

        SupportTicketInput IEditableEntity<SupportTicketInput>.ToInput()
        {
            throw new NotImplementedException();
        }

        public string GetModificationUrl()
        {
            throw new NotImplementedException();
        }
    }
}