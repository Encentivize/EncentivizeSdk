namespace Entelect.Encentivize.Sdk.SupportTickets.Categories
{
    public interface ISupportTicketCategoriesClient
    {
        SupportTicketCategoryOutput Get(long supportTicketCategoryId);
        PagedResult<SupportTicketCategoryOutput> Search(SupportTicketCategorySearchCriteria supportTicketCategorySearchCriteria);
    }
}