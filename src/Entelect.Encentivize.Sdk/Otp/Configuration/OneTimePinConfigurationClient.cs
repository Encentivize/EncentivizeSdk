﻿using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfigurationClient
    {
        private readonly IEntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<OneTimePinConfigurationOutput> _entityRetrievalService;
        private readonly IEntityCreationService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;
        public OneTimePinConfigurationClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("OneTime Pin Configuration", "OneTime Pin Configurations", "OneTimePinConfigurations");
            _entityUpdateService = new EntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<OneTimePinConfigurationOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public OneTimePinConfigurationOutput Get(long oneTimePinTypeId)
        {
            return _entityRetrievalService.GetById(oneTimePinTypeId);
        }

        public PagedResult<OneTimePinConfigurationOutput> Search(OneTimePinConfigurationSearchCriteria oneTimePinConfigurationSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(oneTimePinConfigurationSearchCriteria);
        }

        public OneTimePinConfigurationOutput Create(OneTimePinConfigurationInput oneTimePinConfigurationInput)
        {
            return _entityCreationService.Create(oneTimePinConfigurationInput);
        }

        public OneTimePinConfigurationOutput Update(long oneTimePinTypeId, OneTimePinConfigurationInput oneTimePinConfigurationInput)
        {
            return _entityUpdateService.Update(oneTimePinTypeId, oneTimePinConfigurationInput);
        }

        public void Delete(long oneTimePinTypeId)
        {
            _entityDeletionService.Delete(oneTimePinTypeId);
        }
    }
}