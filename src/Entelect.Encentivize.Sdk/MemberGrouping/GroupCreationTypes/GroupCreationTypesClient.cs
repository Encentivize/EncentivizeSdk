using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes
{
    public class GroupCreationTypesClient : IGroupCreationTypesClient
    {
        private readonly IEntityRetrievalService<GroupCreationType> _entityRetrievalService;

        public GroupCreationTypesClient(IEntityRetrievalService<GroupCreationType> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public GroupCreationTypesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings(typeof(GroupCreationType));
            _entityRetrievalService = new EntityRetrievalService<GroupCreationType>(restClient, entitySettings);
        }

        public virtual GroupCreationType Get(long groupCreationTypeId)
        {
            return _entityRetrievalService.GetById(groupCreationTypeId);
        }

        public virtual PagedResult<GroupCreationType> Search(GroupCreationTypeSearchCriteria groupCreationTypeSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(groupCreationTypeSearchCriteria);
        }

    }
}