using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Groups
{
    public class GroupsClient : IGroupsClient
    {
        private readonly IEntityUpdateService<GroupInput, GroupOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupOutput> _entityRetrievalService;
        private readonly IEntityCreationService<GroupInput, GroupOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;
        public GroupsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Group", "Groups", "Groups");
            _entityUpdateService = new EntityUpdateService<GroupInput, GroupOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupInput, GroupOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public GroupOutput Get(long groupId)
        {
            return _entityRetrievalService.GetById(groupId);
        }

        public PagedResult<GroupOutput> Search(GroupSearchCriteria groupSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupSearchCriteria);
        }

        public GroupOutput Create(GroupInput groupInput)
        {
            return _entityCreationService.Create(groupInput);
        }

        public GroupOutput Update(long groupId, GroupInput groupInput)
        {
            return _entityUpdateService.Update(groupId, groupInput);
        }

        public void Delete(long groupId)
        {
            _entityDeletionService.Delete(groupId);
        }
    }
}