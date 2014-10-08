using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public class MemberAchievementsClient : IMemberAchievementsClient
    {
        private readonly IEntityRetrievalService<MemberAchievement> _entityRetrievalService;
        private readonly IEntityCreationService<MemberAchievementInput, MemberAchievement> _entityCreationService;
        private readonly IEntityDeletionService<MemberAchievementInput, MemberAchievement> _entityDeletionService;

        public MemberAchievementsClient(IEntityRetrievalService<MemberAchievement> entityRetrievalService, 
            IEntityCreationService<MemberAchievementInput, MemberAchievement> entityCreationService,
            IEntityDeletionService<MemberAchievementInput, MemberAchievement> entityDeletionService)
        {
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public MemberAchievementsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings<MemberAchievement>("Member Achievement", "Member Achievements", "MemberAchievements");
            _entityRetrievalService = new EntityRetrievalService<MemberAchievement>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<MemberAchievementInput, MemberAchievement>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService<MemberAchievementInput, MemberAchievement>(restClient, entitySettings);
        }

        public virtual PagedResult<MemberAchievement> Search(MemberAchievementSearchCriteria memberAchievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(memberAchievementSearchCriteria);
        }

        public virtual PagedResult<MemberAchievement> SearchMembersAchievements(long memberId, MemberAchievementSearchCriteria memberAchievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(GetMemberPath(memberId), memberAchievementSearchCriteria);
        }

        public virtual MemberAchievement AwardAchievement(long memberId, MemberAchievementInput memberAchievementInput)
        {
            return _entityCreationService.Create(GetMemberPath(memberId), memberAchievementInput);
        }

        public virtual void RetractAchievement(long memberId, long memberAchievementId)
        {
            _entityDeletionService.Delete(string.Format("{0}{1}", GetMemberPath(memberId), memberAchievementId));
        }

        protected virtual string GetMemberPath(long memberId)
        {
            return string.Format("members/{0}/achievements/", memberId);
        }
    }
}