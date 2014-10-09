using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public class AchievementsClient : IAchievementClient
    {
        private readonly IEntityUpdateService<AchievementInput, Achievement> _entityUpdateService;
        private readonly IEntityRetrievalService<Achievement> _entityRetrievalService;
        private readonly IEntityCreationService<AchievementInput, Achievement> _entityCreationService;
        private readonly IEntityDeletionService<AchievementInput, Achievement> _entityDeletionService;

        public AchievementsClient(IEntityUpdateService<AchievementInput, Achievement> entityUpdateService, 
            IEntityRetrievalService<Achievement> entityRetrievalService, 
            IEntityCreationService<AchievementInput, Achievement> entityCreationService,
            IEntityDeletionService<AchievementInput, Achievement> entityDeletionService)
        {
            _entityUpdateService = entityUpdateService;
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public AchievementsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings().Populate<Achievement>();
            _entityUpdateService = new EntityUpdateService<AchievementInput, Achievement>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<Achievement>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<AchievementInput, Achievement>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<AchievementInput, Achievement>(restClient, entitySettings);
        }

        public virtual Achievement Get(long achievementId)
        {
            return _entityRetrievalService.GetById(achievementId);
        }

        public virtual PagedResult<Achievement> Search(AchievementSearchCriteria achievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(achievementSearchCriteria);
        }

        public virtual PagedResult<Achievement> AvailableAchievements(long memberId, AchievementSearchCriteria achievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(string.Format("members/{0}/availableAchievements/", memberId), achievementSearchCriteria);
        }

        public virtual Achievement Create(AchievementInput achievementInput)
        {
            return _entityCreationService.Create(achievementInput);
        }

        public virtual Achievement Update(long achievementId, AchievementInput achievementInput)
        {
            return _entityUpdateService.Update(achievementId, achievementInput);
        }

        public Achievement Update(Achievement achievement)
        {
            return _entityUpdateService.Update(achievement);
        }

        public virtual void Delete(long achievementId)
        {
            _entityDeletionService.Delete(achievementId);
        }

        public void Delete(Achievement achievement)
        {
            _entityDeletionService.Delete(achievement);
        }
    }
}