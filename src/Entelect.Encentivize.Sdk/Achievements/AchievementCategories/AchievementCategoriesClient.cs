using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategoriesClient : IAchievementCategoryClient
    {
        private readonly IEntityUpdateService<AchievementCategoryInput, AchievementCategory> _entityUpdateService;
        private readonly IEntityRetrievalService<AchievementCategory> _entityRetrievalService;
        private readonly IEntityCreationService<AchievementCategoryInput, AchievementCategory> _entityCreationService;
        private readonly IEntityDeletionService<AchievementCategoryInput, AchievementCategory> _entityDeletionService;

        public AchievementCategoriesClient(IEntityUpdateService<AchievementCategoryInput, AchievementCategory> entityUpdateService, 
            IEntityRetrievalService<AchievementCategory> entityRetrievalService, 
            IEntityCreationService<AchievementCategoryInput, AchievementCategory> entityCreationService,
            IEntityDeletionService<AchievementCategoryInput, AchievementCategory> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public AchievementCategoriesClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings().Populate<AchievementCategory>();
            _entityUpdateService = new EntityUpdateService<AchievementCategoryInput, AchievementCategory>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<AchievementCategory>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<AchievementCategoryInput, AchievementCategory>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<AchievementCategoryInput, AchievementCategory>(restClient, entitySettings);
        }

        public virtual AchievementCategory Get(long achievementCategoryId)
        {
            return _entityRetrievalService.GetById(achievementCategoryId);
        }

        public virtual PagedResult<AchievementCategory> Search(AchievementCategorySearchCriteria achievementCategorySearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(achievementCategorySearchCriteria);
        }

        public virtual AchievementCategory Create(AchievementCategoryInput achievementCategoryInput)
        {
            return _entityCreationService.Create(achievementCategoryInput);
        }

        public virtual AchievementCategory Update(long achievementCategoryId, AchievementCategoryInput achievementCategoryInput)
        {
            return _entityUpdateService.Update(achievementCategoryId, achievementCategoryInput);
        }

        public AchievementCategory Update(AchievementCategory achievementCategory)
        {
            return _entityUpdateService.Update(achievementCategory);
        }

        public virtual void Delete(long achievementCategoryId)
        {
            _entityDeletionService.Delete(achievementCategoryId);
        }

        public void Delete(AchievementCategory achievementCategory)
        {
            _entityDeletionService.Delete(achievementCategory);
        }
    }
}