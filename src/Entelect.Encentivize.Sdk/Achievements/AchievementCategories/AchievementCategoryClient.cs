using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategoryClient : IAchievementCategoryClient
    {
        private readonly IEntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<AchievementCategoryOutput> _entityRetrievalService;
        private readonly IEntityCreationService<AchievementCategoryInput, AchievementCategoryOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;
        private const string EntityString = "AchievementCategories";
        public AchievementCategoryClient(IRestClient restClient)
        {
            _entityUpdateService = new EntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, EntityString);
            _entityRetrievalService = new EntityRetrievalService<AchievementCategoryOutput>(restClient, EntityString);
            _entityCreationService = new EntityCreationService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, EntityString);
            _entityDeletionService = new EntityDeletionService(restClient, EntityString);
        }

        public AchievementCategoryOutput Get(long achievementCategoryId)
        {
            return _entityRetrievalService.GetById(achievementCategoryId);
        }

        public PagedResult<AchievementCategoryOutput> Search(AchievementCategorySearchCriteria achievementCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(achievementCategorySearchCriteria);
        }

        public AchievementCategoryOutput Create(AchievementCategoryInput achievementCategoryInput)
        {
            return _entityCreationService.Create(achievementCategoryInput);
        }

        public AchievementCategoryOutput Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput)
        {
            return _entityUpdateService.Update(achievementCategoryId, achievementCategoryInput);
        }

        public void Delete(long achievementCategoryId)
        {
            _entityDeletionService.Delete(achievementCategoryId);
        }
    }
}