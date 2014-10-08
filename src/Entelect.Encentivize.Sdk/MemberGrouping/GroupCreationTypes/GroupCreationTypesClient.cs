using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes
{
    public class GroupCreationTypesClient : IGroupCreationTypesClient
    {
        private readonly IEntityRetrievalService<GroupCreationTypeOutput> _entityRetrievalService;
        public GroupCreationTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Group Creation Type", "Group Creation Types", "GroupCreationTypes");
            _entityRetrievalService = new EntityRetrievalService<GroupCreationTypeOutput>(restClient, entitySettings);
        }

        public virtual GroupCreationTypeOutput Get(long groupCreationTypeId)
        {
            return _entityRetrievalService.GetById(groupCreationTypeId);
        }

        public virtual PagedResult<GroupCreationTypeOutput> Search(GroupCreationTypeSearchCriteria groupCreationTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupCreationTypeSearchCriteria);
        }

    }
}