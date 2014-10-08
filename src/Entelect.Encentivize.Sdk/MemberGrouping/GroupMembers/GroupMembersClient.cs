using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public class GroupMembersClient : IGroupMembersClient
    {
        private readonly IEncentivizeRestClient _restClient;
        private IEntityUpdateService<GroupMemberInput, GroupMemberOutput> _entityUpdateService;
        private IEntityRetrievalService<GroupMemberOutput> _entityRetrievalService;
        private IEntityCreationService<GroupMemberInput, GroupMemberOutput> _entityCreationService;
        private IEntityDeletionService _entityDeletionService;
        private const string SingularEntityName = "Group Member";
        private const string PluralEntityName = "Group Members";
        public GroupMembersClient(IEncentivizeRestClient restClient)
        {
            _restClient = restClient;
            
        }

        public PagedResult<GroupMemberOutput> GetMembersInGroup(long groupId)
        {
            InitialiseServices(groupId);
            return _entityRetrievalService.FindBySearchCriteria(new BaseSearchCriteria(1, int.MaxValue));
        }

        public GroupMemberOutput AddMemberToGroup(GroupMemberInput groupMemberInput, long groupId)
        {
            InitialiseServices(groupId);
            return _entityCreationService.Create(groupMemberInput);
        }

        public GroupMemberOutput UpdateMemberRole(long groupId, GroupMemberInput groupMemberInput)
        {
            InitialiseServices(groupId);
            return _entityUpdateService.Update(string.Format("Groups/{0}/Members/{1}", groupId, groupMemberInput.MemberId), groupMemberInput);
        }

        public void RemovedMemberFromGroup(long groupId, long memberId)
        {
            InitialiseServices(groupId);
            _entityDeletionService.Delete(string.Format("Groups/{0}/Members/{1}", groupId, memberId));
        }

        private void InitialiseServices(long groupId)
        {
            var entitySettings = new EntitySettings(SingularEntityName, PluralEntityName, string.Format("Groups/{0}/Members", groupId));
            _entityUpdateService = new EntityUpdateService<GroupMemberInput, GroupMemberOutput>(_restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupMemberOutput>(_restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupMemberInput, GroupMemberOutput>(_restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(_restClient, entitySettings);
        }
    }
}