using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.SupportTickets.Types
{
    public class SupportTicketTypesClient : ISupportTicketTypesClient
    {
        private readonly IEntityRetrievalService<SupportTicketTypeOutput> _entityRetrievalService;
        public SupportTicketTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Support Ticket Type", "Support Ticket Types", "SupportTicketTypes");
            _entityRetrievalService = new EntityRetrievalService<SupportTicketTypeOutput>(restClient, entitySettings);
        }

        public virtual SupportTicketTypeOutput Get(long supportTicketTypeId)
        {
            return _entityRetrievalService.GetById(supportTicketTypeId);
        }

        public virtual PagedResult<SupportTicketTypeOutput> Search(SupportTicketTypeSearchCriteria supportTicketTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketTypeSearchCriteria);
        }

    }
}