using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public class GroupMembersClient : IGroupMembersClient
    {
        private readonly IEntityUpdateService<GroupMemberInput, GroupMemberOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupMemberOutput> _entityRetrievalService;
        private readonly IEntityCreationService<GroupMemberInput, GroupMemberOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public GroupMembersClient(IEntityUpdateService<GroupMemberInput, GroupMemberOutput> entityUpdateService, 
            IEntityRetrievalService<GroupMemberOutput> entityRetrievalService, 
            IEntityCreationService<GroupMemberInput, GroupMemberOutput> entityCreationService, 
            IEntityDeletionService entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public GroupMembersClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Group Member", "Group Members", "Groups/{groupId:long}/Members");
            _entityUpdateService = new EntityUpdateService<GroupMemberInput, GroupMemberOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupMemberOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupMemberInput, GroupMemberOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual PagedResult<GroupMemberOutput> GetMembersInGroup(long groupId)
        {
            return _entityRetrievalService.FindBySearchCriteria(GroupUrl(groupId), new BaseSearchCriteria(1, int.MaxValue));
        }

        public virtual GroupMemberOutput AddMemberToGroup(GroupMemberInput groupMemberInput, long groupId)
        {
            return _entityCreationService.Create(GroupUrl(groupId), groupMemberInput);
        }

        public virtual GroupMemberOutput UpdateMemberRole(long groupId, GroupMemberInput groupMemberInput)
        {
            return _entityUpdateService.Update(GroupMemberUrl(groupId, groupMemberInput.MemberId), groupMemberInput);
        }

        public virtual void RemovedMemberFromGroup(long groupId, long memberId)
        {
            _entityDeletionService.Delete(GroupMemberUrl(groupId, memberId));
        }

        protected virtual string GroupUrl(long groupId)
        {
            return string.Format("Groups/{0}/Members", groupId);
        }

        protected virtual string GroupMemberUrl(long groupId,long memberId)
        {
            return string.Format("Groups/{0}/Members/{1}", groupId, memberId);
        }
    }
}