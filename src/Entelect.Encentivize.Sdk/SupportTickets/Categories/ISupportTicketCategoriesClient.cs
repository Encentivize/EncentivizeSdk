namespace Entelect.Encentivize.Sdk.SupportTickets.Categories
{
    public interface ISupportTicketCategoriesClient
    {
        SupportTicketCategory Get(long supportTicketCategoryId);
        PagedResult<SupportTicketCategory> Search(SupportTicketCategorySearchCriteria supportTicketCategorySearchCriteria);
    }
}