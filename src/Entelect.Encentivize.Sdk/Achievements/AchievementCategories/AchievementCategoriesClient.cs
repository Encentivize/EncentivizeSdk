using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategoriesClient : IAchievementCategoryClient
    {
        private readonly IEntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<AchievementCategoryOutput> _entityRetrievalService;
        private readonly IEntityCreationService<AchievementCategoryInput, AchievementCategoryOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;
        public AchievementCategoriesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Achievement Category", "Achievement Categories", "AchievementCategories");
            _entityUpdateService = new EntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<AchievementCategoryOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
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