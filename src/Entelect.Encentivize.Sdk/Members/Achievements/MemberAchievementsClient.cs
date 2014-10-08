using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public class MemberAchievementsClient : IMemberAchievementsClient
    {
        private readonly IEntityRetrievalService<MemberAchievementOutput> _entityRetrievalService;
        private readonly IEntityCreationService<MemberAchievementInput, MemberAchievementOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public MemberAchievementsClient(IEntityRetrievalService<MemberAchievementOutput> entityRetrievalService, 
            IEntityCreationService<MemberAchievementInput, MemberAchievementOutput> entityCreationService, 
            IEntityDeletionService entityDeletionService)
        {
            _entityRetrievalService = entityRetrievalService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        public MemberAchievementsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Member Achievement", "Member Achievements", "MemberAchievements");
            _entityRetrievalService = new EntityRetrievalService<MemberAchievementOutput>(restClient, entitySettings);
            _entityCreationService = new EntityCreationService<MemberAchievementInput, MemberAchievementOutput>(restClient, entitySettings);
            _entityDeletionService = new EntityDeletionService(restClient, entitySettings);
        }

        public virtual PagedResult<MemberAchievementOutput> Search(MemberAchievementSearchCriteria memberAchievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(memberAchievementSearchCriteria);
        }

        public virtual PagedResult<MemberAchievementOutput> SearchMembersAchievements(long memberId, MemberAchievementSearchCriteria memberAchievementSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(GetMemberPath(memberId), memberAchievementSearchCriteria);
        }

        public virtual MemberAchievementOutput AwardAchievement(long memberId, MemberAchievementInput memberAchievementInput)
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