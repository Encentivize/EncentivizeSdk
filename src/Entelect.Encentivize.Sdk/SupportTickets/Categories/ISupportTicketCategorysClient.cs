namespace Entelect.Encentivize.Sdk.SupportTickets.Categories
{
    public interface ISupportTicketCategorysClient
    {
        SupportTicketCategoryOutput Get(long supportTicketCategoryId);
        PagedResult<SupportTicketCategoryOutput> Search(SupportTicketCategorySearchCriteria supportTicketCategorySearchCriteria);
    }
}