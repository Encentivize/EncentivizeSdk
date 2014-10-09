using System;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class Comment
    {
        public long SupportTicketCommentId { get; set; }
        public string CommentBody { get; set; }
        public long CreatedById { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public long SupportTicketId { get; set; }
    }
}