using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.SupportTickets.Types
{
    public class SupportTicketTypesClient : ISupportTicketTypesClient
    {
        private readonly IEntityRetrievalService<SupportTicketType> _entityRetrievalService;

        public SupportTicketTypesClient(IEntityRetrievalService<SupportTicketType> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public SupportTicketTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Support Ticket Type", "Support Ticket Types", "SupportTicketTypes");
            _entityRetrievalService = new EntityRetrievalService<SupportTicketType>(restClient, entitySettings);
        }

        public virtual SupportTicketType Get(long supportTicketTypeId)
        {
            return _entityRetrievalService.GetById(supportTicketTypeId);
        }

        public virtual PagedResult<SupportTicketType> Search(SupportTicketTypeSearchCriteria supportTicketTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketTypeSearchCriteria);
        }

    }
}