using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class SupportTicketsClient : ISupportTicketsClient
    {
        private readonly IEntityUpdateService<EditSupportTicketInput, SupportTicket> _entityUpdateService;
        private readonly IEntityRetrievalService<SupportTicket> _entityRetrievalService;
        private readonly IEntityCreationService<SupportTicketInput, SupportTicket> _entityCreationService;

        public SupportTicketsClient(IEntityUpdateService<EditSupportTicketInput, SupportTicket> entityUpdateService, 
            IEntityRetrievalService<SupportTicket> entityRetrievalService, 
            IEntityCreationService<SupportTicketInput, SupportTicket> entityCreationService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
        }

        public SupportTicketsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings(typeof(SupportTicket));
            _entityUpdateService = new EntityUpdateService<EditSupportTicketInput, SupportTicket>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<SupportTicket>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<SupportTicketInput, SupportTicket>(restClient, entitySettings);
        }

        public virtual SupportTicket Get(long supportTicketId)
        {
            return _entityRetrievalService.GetById(supportTicketId);
        }

        public virtual PagedResult<SupportTicket> Search(SupportTicketSearchCriteria supportTicketSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketSearchCriteria);
        }

        public virtual SupportTicket Create(SupportTicketInput supportTicketInput)
        {
            return _entityCreationService.Create(supportTicketInput);
        }

        public virtual SupportTicket Update(long supportTicketId, EditSupportTicketInput editSupportTicketInput)
        {
            return _entityUpdateService.Update(supportTicketId, editSupportTicketInput);
        }
    }
}