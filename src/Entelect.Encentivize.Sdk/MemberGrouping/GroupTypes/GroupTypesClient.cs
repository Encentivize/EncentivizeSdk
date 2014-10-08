using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupTypesClient : IGroupTypeClient
    {
        private readonly IEntityUpdateService<GroupTypeInput, GroupType> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupType> _entityRetrievalService;
        private readonly IEntityCreationService<GroupTypeInput, GroupType> _entityCreationService;
        private readonly IEntityDeletionService<GroupTypeInput, GroupType> _entityDeletionService;

        public GroupTypesClient(IEntityUpdateService<GroupTypeInput, GroupType> entityUpdateService, 
            IEntityRetrievalService<GroupType> entityRetrievalService, 
            IEntityCreationService<GroupTypeInput, GroupType> entityCreationService,
            IEntityDeletionService<GroupTypeInput, GroupType> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public GroupTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings<GroupType>("Group Type", "Group Types", "GroupTypes");
            _entityUpdateService = new EntityUpdateService<GroupTypeInput, GroupType>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupType>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupTypeInput, GroupType>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<GroupTypeInput, GroupType>(restClient, entitySettings);
        }

        public virtual GroupType Get(long groupTypeId)
        {
            return _entityRetrievalService.GetById(groupTypeId);
        }

        public virtual PagedResult<GroupType> Search(GroupTypeSearchCriteria groupTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupTypeSearchCriteria);
        }

        public virtual GroupType Create(GroupTypeInput groupTypeInput)
        {
            return _entityCreationService.Create(groupTypeInput);
        }

        public virtual GroupType Update(long groupTypeId, GroupTypeInput groupTypeInput)
        {
            return _entityUpdateService.Update(groupTypeId, groupTypeInput);
        }

        public virtual void Delete(long groupTypeId)
        {
            _entityDeletionService.Delete(groupTypeId);
        }
    }
}