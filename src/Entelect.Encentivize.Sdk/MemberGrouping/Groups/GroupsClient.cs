using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public class GroupsClient : IGroupsClient
    {
        private readonly IEntityUpdateService<GroupInput, Group> _entityUpdateService;
        private readonly IEntityRetrievalService<Group> _entityRetrievalService;
        private readonly IEntityCreationService<GroupInput, Group> _entityCreationService;
        private readonly IEntityDeletionService<GroupInput, Group> _entityDeletionService;

        public GroupsClient(IEntityUpdateService<GroupInput, Group> entityUpdateService, 
            IEntityRetrievalService<Group> entityRetrievalService, 
            IEntityCreationService<GroupInput, Group> entityCreationService,
            IEntityDeletionService<GroupInput, Group> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public GroupsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings().Populate<Group>();
            _entityUpdateService = new EntityUpdateService<GroupInput, Group>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<Group>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupInput, Group>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<GroupInput, Group>(restClient, entitySettings);
        }

        public virtual Group Get(long groupId)
        {
            return _entityRetrievalService.GetById(groupId);
        }

        public virtual PagedResult<Group> GetGroupsForMember(long memberId, GroupMemberSearchCriteria groupMemberSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(string.Format("members/{0}/groups", memberId), groupMemberSearchCriteria);
        }

        public virtual PagedResult<Group> Search(GroupSearchCriteria groupSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupSearchCriteria);
        }

        public virtual Group Create(GroupInput groupInput)
        {
            return _entityCreationService.Create(groupInput);
        }

        public virtual Group Update(long groupId, GroupInput groupInput)
        {
            return _entityUpdateService.Update(groupId, groupInput);
        }

        public virtual void Delete(long groupId)
        {
            _entityDeletionService.Delete(groupId);
        }
    }
}