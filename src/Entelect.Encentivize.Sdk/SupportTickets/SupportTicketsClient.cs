using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class SupportTicketsClient : ISupportTicketsClient
    {
        private readonly IEntityUpdateService<EditSupportTicketInput, SupportTicketOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<SupportTicketOutput> _entityRetrievalService;
        private readonly IEntityCreationService<SupportTicketInput, SupportTicketOutput> _entityCreationService;

        public SupportTicketsClient(IEntityUpdateService<EditSupportTicketInput, SupportTicketOutput> entityUpdateService, 
            IEntityRetrievalService<SupportTicketOutput> entityRetrievalService, 
            IEntityCreationService<SupportTicketInput, SupportTicketOutput> entityCreationService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
        }

        public SupportTicketsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Support Ticket", "Support Tickets", "SupportTickets");
            _entityUpdateService = new EntityUpdateService<EditSupportTicketInput, SupportTicketOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<SupportTicketOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<SupportTicketInput, SupportTicketOutput>(restClient, entitySettings);
        }

        public virtual SupportTicketOutput Get(long supportTicketId)
        {
            return _entityRetrievalService.GetById(supportTicketId);
        }

        public virtual PagedResult<SupportTicketOutput> Search(SupportTicketSearchCriteria supportTicketSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketSearchCriteria);
        }

        public virtual SupportTicketOutput Create(SupportTicketInput supportTicketInput)
        {
            return _entityCreationService.Create(supportTicketInput);
        }

        public virtual SupportTicketOutput Update(long supportTicketId, EditSupportTicketInput editSupportTicketInput)
        {
            return _entityUpdateService.Update(supportTicketId, editSupportTicketInput);
        }
    }
}