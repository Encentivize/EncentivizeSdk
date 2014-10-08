using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public class AchievementsClient : IAchievementClient
    {
        private readonly EntityUpdateService<AchievementInput, AchievementOutput> _entityUpdateService;
        private readonly EntityRetrievalService<AchievementOutput> _entityRetrievalService;
        private readonly EntityCreationService<AchievementInput, AchievementOutput> _entityCreationService;
        private readonly EntityDeletionService _entityDeletionService;

        public AchievementsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Achievement", "Achievements", "Achievements");
            _entityUpdateService = new EntityUpdateService<AchievementInput, AchievementOutput>(restClient, entitySettings);
            _entityRetrievalService = new EntityRetrievalService<AchievementOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<AchievementInput, AchievementOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual AchievementOutput Get(long achievementId)
        {
            return _entityRetrievalService.GetById(achievementId);
        }

        public virtual PagedResult<AchievementOutput> Search(AchievementSearchCriteria achievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(achievementSearchCriteria);
        }

        public virtual AchievementOutput Create(AchievementInput achievementInput)
        {
            return _entityCreationService.Create(achievementInput);
        }

        public virtual AchievementOutput Update(long achievementId, AchievementInput achievementInput)
        {
            return _entityUpdateService.Update(achievementId, achievementInput);
        }

        public virtual void Delete(long achievementId)
        {
            _entityDeletionService.Delete(achievementId);
        }
    }
}