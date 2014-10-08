using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Configuration
{
    public class OneTimePinConfigurationsClient : IOneTimePinConfigurationsClient
    {
        private readonly IEntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<OneTimePinConfigurationOutput> _entityRetrievalService;
        private readonly IEntityCreationService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public OneTimePinConfigurationsClient(IEntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput> entityUpdateService, 
            IEntityRetrievalService<OneTimePinConfigurationOutput> entityRetrievalService, 
            IEntityCreationService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput> entityCreationService, 
            IEntityDeletionService entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public OneTimePinConfigurationsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("OneTime Pin Configuration", "OneTime Pin Configurations", "OneTimePinConfigurations");
            _entityUpdateService = new EntityUpdateService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<OneTimePinConfigurationOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<OneTimePinConfigurationInput, OneTimePinConfigurationOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual OneTimePinConfigurationOutput Get(long oneTimePinTypeId)
        {
            return _entityRetrievalService.GetById(oneTimePinTypeId);
        }

        public virtual PagedResult<OneTimePinConfigurationOutput> Search(OneTimePinConfigurationSearchCriteria oneTimePinConfigurationSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(oneTimePinConfigurationSearchCriteria);
        }

        public virtual OneTimePinConfigurationOutput Create(OneTimePinConfigurationInput oneTimePinConfigurationInput)
        {
            return _entityCreationService.Create(oneTimePinConfigurationInput);
        }

        public virtual OneTimePinConfigurationOutput Update(OneTimePinConfigurationInput oneTimePinConfigurationInput)
        {
            return _entityUpdateService.Update(oneTimePinConfigurationInput.OneTimePinTypeId, oneTimePinConfigurationInput);
        }

        public virtual void Delete(long oneTimePinTypeId)
        {
            _entityDeletionService.Delete(oneTimePinTypeId);
        }
    }
}