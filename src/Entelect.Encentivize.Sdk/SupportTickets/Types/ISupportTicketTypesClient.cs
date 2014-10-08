namespace Entelect.Encentivize.Sdk.SupportTickets.Types
{
    public interface ISupportTicketTypesClient
    {
        SupportTicketType Get(long supportTicketTypeId);
        PagedResult<SupportTicketType> Search(SupportTicketTypeSearchCriteria supportTicketTypeSearchCriteria);
    }
}