﻿using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.SupportTickets.Types
{
    public class SupportTicketTypesClient : ISupportTicketTypesClient
    {
        private readonly IEntityRetrievalService<SupportTicketTypeOutput> _entityRetrievalService;
        public SupportTicketTypesClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("SupportTicketType", "SupportTicketTypes", "SupportTicketTypes");
            _entityRetrievalService = new EntityRetrievalService<SupportTicketTypeOutput>(restClient, entitySettings);
        }

        public SupportTicketTypeOutput Get(long supportTicketTypeId)
        {
            return _entityRetrievalService.GetById(supportTicketTypeId);
        }

        public PagedResult<SupportTicketTypeOutput> Search(SupportTicketTypeSearchCriteria supportTicketTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(supportTicketTypeSearchCriteria);
        }

    }
}