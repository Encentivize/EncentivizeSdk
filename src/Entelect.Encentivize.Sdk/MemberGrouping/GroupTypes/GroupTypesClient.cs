using Entelect.Encentivize.Sdk.Achievements.GroupTypes;
using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes
{
    public class GroupTypesClient : IGroupTypeClient
    {
        private readonly IEntityUpdateService<GroupTypeInput, GroupTypeOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<GroupTypeOutput> _entityRetrievalService;
        private readonly IEntityCreationService<GroupTypeInput, GroupTypeOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;
        public GroupTypesClient(IRestClient restClient)
        {
            var entitySettings = new EntitySettings("Group Type", "Group Types", "GroupTypes");
            _entityUpdateService = new EntityUpdateService<GroupTypeInput, GroupTypeOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<GroupTypeOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<GroupTypeInput, GroupTypeOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public GroupTypeOutput Get(long groupTypeId)
        {
            return _entityRetrievalService.GetById(groupTypeId);
        }

        public PagedResult<GroupTypeOutput> Search(GroupTypeSearchCriteria groupTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupTypeSearchCriteria);
        }

        public GroupTypeOutput Create(GroupTypeInput groupTypeInput)
        {
            return _entityCreationService.Create(groupTypeInput);
        }

        public GroupTypeOutput Update(long groupTypeId, GroupTypeInput groupTypeInput)
        {
            return _entityUpdateService.Update(groupTypeId, groupTypeInput);
        }

        public void Delete(long groupTypeId)
        {
            _entityDeletionService.Delete(groupTypeId);
        }
    }
}