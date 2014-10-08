using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategoriesClient : IAchievementCategoryClient
    {
        private readonly IEntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput> _entityUpdateService;
        private readonly IEntityRetrievalService<AchievementCategoryOutput> _entityRetrievalService;
        private readonly IEntityCreationService<AchievementCategoryInput, AchievementCategoryOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public AchievementCategoriesClient(IEntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput> entityUpdateService, 
            IEntityRetrievalService<AchievementCategoryOutput> entityRetrievalService, 
            IEntityCreationService<AchievementCategoryInput, AchievementCategoryOutput> entityCreationService, 
            IEntityDeletionService entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public AchievementCategoriesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Achievement Category", "Achievement Categories", "AchievementCategories");
            _entityUpdateService = new EntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<AchievementCategoryOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual AchievementCategoryOutput Get(long achievementCategoryId)
        {
            return _entityRetrievalService.GetById(achievementCategoryId);
        }

        public virtual PagedResult<AchievementCategoryOutput> Search(AchievementCategorySearchCriteria achievementCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(achievementCategorySearchCriteria);
        }

        public virtual AchievementCategoryOutput Create(AchievementCategoryInput achievementCategoryInput)
        {
            return _entityCreationService.Create(achievementCategoryInput);
        }

        public virtual AchievementCategoryOutput Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput)
        {
            return _entityUpdateService.Update(achievementCategoryId, achievementCategoryInput);
        }

        public virtual void Delete(long achievementCategoryId)
        {
            _entityDeletionService.Delete(achievementCategoryId);
        }
    }
}