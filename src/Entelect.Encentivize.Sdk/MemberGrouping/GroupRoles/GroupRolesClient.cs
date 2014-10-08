using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRolesClient : IGroupRolesClient
    {
        private readonly IEntityUpdateService<GroupRoleInput, GroupRoleOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupRoleOutput> _entityRetrievalService;
        private readonly IEntityCreationService<GroupRoleInput, GroupRoleOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public GroupRolesClient(IEntityUpdateService<GroupRoleInput, GroupRoleOutput> entityUpdateService, 
            IEntityRetrievalService<GroupRoleOutput> entityRetrievalService, 
            IEntityCreationService<GroupRoleInput, GroupRoleOutput> entityCreationService, 
            IEntityDeletionService entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public GroupRolesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Group Role", "Group Roles", "GroupRoles");
            _entityUpdateService = new EntityUpdateService<GroupRoleInput, GroupRoleOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupRoleOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupRoleInput, GroupRoleOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual GroupRoleOutput Get(long groupRoleId)
        {
            return _entityRetrievalService.GetById(groupRoleId);
        }

        public virtual PagedResult<GroupRoleOutput> Search(GroupRoleSearchCriteria groupRoleSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupRoleSearchCriteria);
        }

        public virtual GroupRoleOutput Create(GroupRoleInput groupRoleInput)
        {
            return _entityCreationService.Create(groupRoleInput);
        }

        public virtual GroupRoleOutput Update(long groupRoleId, GroupRoleInput groupRoleInput)
        {
            return _entityUpdateService.Update(groupRoleId, groupRoleInput);
        }

        public virtual void Delete(long groupRoleId)
        {
            _entityDeletionService.Delete(groupRoleId);
        }
    }
}