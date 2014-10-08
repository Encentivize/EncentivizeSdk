using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfigurationsClient : IOneTimePinConfigurationsClient
    {
        private readonly IEntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfiguration> _entityUpdateService;
        private readonly IEntityRetrievalService<OneTimePinConfiguration> _entityRetrievalService;
        private readonly IEntityCreationService<OneTimePinConfigurationInput, OneTimePinConfiguration> _entityCreationService;
        private readonly IEntityDeletionService<OneTimePinConfigurationInput, OneTimePinConfiguration> _entityDeletionService;

        public OneTimePinConfigurationsClient(IEntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfiguration> entityUpdateService, 
            IEntityRetrievalService<OneTimePinConfiguration> entityRetrievalService, 
            IEntityCreationService<OneTimePinConfigurationInput, OneTimePinConfiguration> entityCreationService,
            IEntityDeletionService<OneTimePinConfigurationInput, OneTimePinConfiguration> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public OneTimePinConfigurationsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings<OneTimePinConfiguration>("OneTime Pin Configuration", "OneTime Pin Configurations", "OneTimePinConfigurations");
            _entityUpdateService = new EntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfiguration>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<OneTimePinConfiguration>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<OneTimePinConfigurationInput, OneTimePinConfiguration>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<OneTimePinConfigurationInput, OneTimePinConfiguration>(restClient, entitySettings);
        }

        public virtual OneTimePinConfiguration Get(long oneTimePinTypeId)
        {
            return _entityRetrievalService.GetById(oneTimePinTypeId);
        }

        public virtual PagedResult<OneTimePinConfiguration> Search(OneTimePinConfigurationSearchCriteria oneTimePinConfigurationSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(oneTimePinConfigurationSearchCriteria);
        }

        public virtual OneTimePinConfiguration Create(OneTimePinConfigurationInput oneTimePinConfigurationInput)
        {
            return _entityCreationService.Create(oneTimePinConfigurationInput);
        }

        public virtual OneTimePinConfiguration Update(OneTimePinConfigurationInput oneTimePinConfigurationInput)
        {
            return _entityUpdateService.Update(oneTimePinConfigurationInput.OneTimePinTypeId, oneTimePinConfigurationInput);
        }

        public virtual void Delete(long oneTimePinTypeId)
        {
            _entityDeletionService.Delete(oneTimePinTypeId);
        }
    }
}