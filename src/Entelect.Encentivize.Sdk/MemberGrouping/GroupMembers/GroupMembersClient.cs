using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public class GroupMembersClient : IGroupMembersClient
    {
        private readonly IEntityUpdateService<GroupMemberInput, GroupMember> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupMember> _entityRetrievalService;
        private readonly IEntityCreationService<GroupMemberInput, GroupMember> _entityCreationService;
        private readonly IEntityDeletionService<GroupMemberInput, GroupMember> _entityDeletionService;

        public GroupMembersClient(IEntityUpdateService<GroupMemberInput, GroupMember> entityUpdateService, 
            IEntityRetrievalService<GroupMember> entityRetrievalService, 
            IEntityCreationService<GroupMemberInput, GroupMember> entityCreationService,
            IEntityDeletionService<GroupMemberInput, GroupMember> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public GroupMembersClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings().Populate<GroupMember>();
            _entityUpdateService = new EntityUpdateService<GroupMemberInput, GroupMember>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupMember>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupMemberInput, GroupMember>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<GroupMemberInput, GroupMember>(restClient, entitySettings);
        }

        public virtual PagedResult<GroupMember> GetMembersInGroup(long groupId)
        {
            return _entityRetrievalService.FindBySearchCriteria(GroupUrl(groupId), new BaseSearchCriteria(1, int.MaxValue));
        }

        public virtual GroupMember AddMemberToGroup(GroupMemberInput groupMemberInput, long groupId)
        {
            return _entityCreationService.Create(GroupUrl(groupId), groupMemberInput);
        }

        public virtual GroupMember UpdateMemberRole(GroupMember groupMember)
        {
            return _entityUpdateService.Update(groupMember);
        }

        public virtual GroupMember UpdateMemberRole(long groupId, GroupMemberInput groupMemberInput)
        {
            return _entityUpdateService.Update(GroupMember.GetModificationUrl(groupId, groupMemberInput.MemberId), groupMemberInput);
        }

        public virtual void RemovedMemberFromGroup(long groupId, long memberId)
        {
            _entityDeletionService.Delete(GroupMember.GetModificationUrl(groupId, memberId));
        }

        protected virtual string GroupUrl(long groupId)
        {
            return string.Format("Groups/{0}/Members", groupId);
        }
    }
}