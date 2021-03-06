﻿using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRolesClient : IGroupRolesClient
    {
        private readonly IEntityUpdateService<GroupRoleInput, GroupRole> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupRole> _entityRetrievalService;
        private readonly IEntityCreationService<GroupRoleInput, GroupRole> _entityCreationService;
        private readonly IEntityDeletionService<GroupRoleInput, GroupRole> _entityDeletionService;

        public GroupRolesClient(IEntityUpdateService<GroupRoleInput, GroupRole> entityUpdateService, 
            IEntityRetrievalService<GroupRole> entityRetrievalService, 
            IEntityCreationService<GroupRoleInput, GroupRole> entityCreationService,
            IEntityDeletionService<GroupRoleInput, GroupRole> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public GroupRolesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings().Populate<GroupRole>();
            _entityUpdateService = new EntityUpdateService<GroupRoleInput, GroupRole>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupRole>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupRoleInput, GroupRole>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<GroupRoleInput, GroupRole>(restClient, entitySettings);
        }

        public virtual GroupRole Get(long groupRoleId)
        {
            return _entityRetrievalService.GetById(groupRoleId);
        }

        public virtual PagedResult<GroupRole> Search(GroupRoleSearchCriteria groupRoleSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupRoleSearchCriteria);
        }

        public virtual GroupRole Create(GroupRoleInput groupRoleInput)
        {
            return _entityCreationService.Create(groupRoleInput);
        }

        public virtual GroupRole Update(long groupRoleId, GroupRoleInput groupRoleInput)
        {
            return _entityUpdateService.Update(groupRoleId, groupRoleInput);
        }

        public GroupRole Update(GroupRole groupRole)
        {
            return _entityUpdateService.Update(groupRole);
        }

        public virtual void Delete(long groupRoleId)
        {
            _entityDeletionService.Delete(groupRoleId);
        }

        public void Delete(GroupRole groupRole)
        {
            _entityDeletionService.Delete(groupRole);
        }
    }
}