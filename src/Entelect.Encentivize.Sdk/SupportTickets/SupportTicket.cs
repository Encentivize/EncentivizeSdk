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
            return new EditSupportTicketInput
            {
                IsResolved = IsResolved,
                NewComment = LatestComment
            };
        }

        SupportTicketInput IEditableEntity<SupportTicketInput>.ToInput()
        {
            return  new SupportTicketInput
            {
                Comment = LatestComment,
                Subject = Subject,
                SupportTicketCategoryId = SupportTicketCategoryId,
                SupportTicketPriorityId = 2, //todo rk
                SupportTicketTypeId = SupportTicketTypeId
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("SupportTickets/{0}", SupportTicketId);
        }
    }
}