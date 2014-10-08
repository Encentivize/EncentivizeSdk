using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.SupportTickets.Categories
{
    public class SupportTicketCategoriesClient : ISupportTicketCategoriesClient
    {
        private readonly IEntityRetrievalService<SupportTicketCategoryOutput> _entityRetrievalService;
        public SupportTicketCategoriesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Support Ticket Category", "Support Ticket Categories", "SupportTicketCategories");
            _entityRetrievalService = new EntityRetrievalService<SupportTicketCategoryOutput>(restClient, entitySettings);
        }

        public virtual SupportTicketCategoryOutput Get(long supportTicketCategoryId)
        {
            return _entityRetrievalService.GetById(supportTicketCategoryId);
        }

        public virtual PagedResult<SupportTicketCategoryOutput> Search(SupportTicketCategorySearchCriteria supportTicketCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketCategorySearchCriteria);
        }

    }
}