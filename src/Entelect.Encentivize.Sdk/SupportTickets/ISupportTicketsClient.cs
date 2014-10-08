namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public interface ISupportTicketsClient
    {
        SupportTicketOutput Get(long supportTicketId);
        PagedResult<SupportTicketOutput> Search(SupportTicketSearchCriteria supportTicketSearchCriteria);
        SupportTicketOutput Create(SupportTicketInput supportTicketInput);
        SupportTicketOutput Update(long supportTicketId, EditSupportTicketInput editSupportTicketInput);
    }
}