using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.SupportTickets.Categories
{
    public class SupportTicketCategorysClient : ISupportTicketCategorysClient
    {
        private readonly IEntityRetrievalService<SupportTicketCategoryOutput> _entityRetrievalService;
        public SupportTicketCategorysClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("SupportTicketCategory", "SupportTicketCategorys", "SupportTicketCategorys");
            _entityRetrievalService = new EntityRetrievalService<SupportTicketCategoryOutput>(restClient, entitySettings);
        }

        public SupportTicketCategoryOutput Get(long supportTicketCategoryId)
        {
            return _entityRetrievalService.GetById(supportTicketCategoryId);
        }

        public PagedResult<SupportTicketCategoryOutput> Search(SupportTicketCategorySearchCriteria supportTicketCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketCategorySearchCriteria);
        }

    }
}