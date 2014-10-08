using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRolesClient : IGroupRolesClient
    {
        private readonly IEntityUpdateService<GroupRoleInput, GroupRoleOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupRoleOutput> _entityRetrievalService;
        private readonly IEntityCreationService<GroupRoleInput, GroupRoleOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;
        public GroupRolesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Group Role", "Group Roles", "GroupRoles");
            _entityUpdateService = new EntityUpdateService<GroupRoleInput, GroupRoleOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupRoleOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupRoleInput, GroupRoleOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public GroupRoleOutput Get(long groupRoleId)
        {
            return _entityRetrievalService.GetById(groupRoleId);
        }

        public PagedResult<GroupRoleOutput> Search(GroupRoleSearchCriteria groupRoleSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupRoleSearchCriteria);
        }

        public GroupRoleOutput Create(GroupRoleInput groupRoleInput)
        {
            return _entityCreationService.Create(groupRoleInput);
        }

        public GroupRoleOutput Update(long groupRoleId, GroupRoleInput groupRoleInput)
        {
            return _entityUpdateService.Update(groupRoleId, groupRoleInput);
        }

        public void Delete(long groupRoleId)
        {
            _entityDeletionService.Delete(groupRoleId);
        }
    }
}