namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public interface ISupportTicketsClient
    {
        SupportTicket Get(long supportTicketId);
        PagedResult<SupportTicket> Search(SupportTicketSearchCriteria supportTicketSearchCriteria);
        SupportTicket Create(SupportTicketInput supportTicketInput);
        SupportTicket Update(long supportTicketId, EditSupportTicketInput editSupportTicketInput);
    }
}