using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.SupportTickets.Categories
{
    public class SupportTicketCategoriesClient : ISupportTicketCategoriesClient
    {
        private readonly IEntityRetrievalService<SupportTicketCategory> _entityRetrievalService;

        public SupportTicketCategoriesClient(IEntityRetrievalService<SupportTicketCategory> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public SupportTicketCategoriesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Support Ticket Category", "Support Ticket Categories", "SupportTicketCategories");
            _entityRetrievalService = new EntityRetrievalService<SupportTicketCategory>(restClient, entitySettings);
        }

        public virtual SupportTicketCategory Get(long supportTicketCategoryId)
        {
            return _entityRetrievalService.GetById(supportTicketCategoryId);
        }

        public virtual PagedResult<SupportTicketCategory> Search(SupportTicketCategorySearchCriteria supportTicketCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketCategorySearchCriteria);
        }

    }
}