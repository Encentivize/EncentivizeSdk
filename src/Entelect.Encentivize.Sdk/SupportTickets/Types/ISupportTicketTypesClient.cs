namespace Entelect.Encentivize.Sdk.SupportTickets.Types
{
    public interface ISupportTicketTypesClient
    {
        SupportTicketTypeOutput Get(long supportTicketTypeId);
        PagedResult<SupportTicketTypeOutput> Search(SupportTicketTypeSearchCriteria supportTicketTypeSearchCriteria);
    }
}