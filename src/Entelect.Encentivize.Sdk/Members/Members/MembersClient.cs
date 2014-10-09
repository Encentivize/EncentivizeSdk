using System;
using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class MembersClient : IMembersClient
    {
        private readonly IEntityRetrievalService<Member> _entityRetrievalService;
        private readonly IEntityUpdateService<MemberInput, Member> _entityUpdateService;
        private readonly IEntityCreationService<MemberInput, Member> _entityCreationService;
        private readonly IEntityRetrievalService _dynamicEntityRetrievalService;
        private readonly IEntityCreationService _dynamicEntityCreationService;

        public MembersClient(IEntityRetrievalService<Member> entityRetrievalService, 
            IEntityUpdateService<MemberInput, Member> entityUpdateService, 
            IEntityCreationService<MemberInput, Member> entityCreationService,
            IEntityRetrievalService dynamicEntityRetrievalService,
            IEntityCreationService dynamicEntityCreationService)
        {
            _entityRetrievalService = entityRetrievalService;
            _entityUpdateService = entityUpdateService;
            _entityCreationService = entityCreationService;
            _dynamicEntityRetrievalService = dynamicEntityRetrievalService;
            _dynamicEntityCreationService = dynamicEntityCreationService;
        }

        public MembersClient(IEncentivizeRestClient restClient)
        {
            var memberSettings = new EntitySettings(typeof(Member));
            _entityRetrievalService = new EntityRetrievalService<Member>(restClient, memberSettings);
            _entityUpdateService = new EntityUpdateService<MemberInput, Member>(restClient, memberSettings);
            _entityCreationService = new EntityCreationService<MemberInput, Member>(restClient, memberSettings);
            _dynamicEntityRetrievalService = new EntityRetrievalService(restClient);
            _dynamicEntityCreationService = new EntityCreationService(restClient);
        }

        public virtual Member GetMe()
        {
            return _entityRetrievalService.Get("members/me");
        }

        public virtual PagedResult<Member> Search(MemberSearchCriteria memberSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(memberSearchCriteria);
        }

        public virtual Member Get(long memberId)
        {
            return _entityRetrievalService.GetById(memberId);
        }

        public virtual Member UpdateMember(long memberId, MemberInput memberInput)
        {
            return _entityUpdateService.Update(memberId, memberInput);
        }

        public virtual Member UpdateMember(Member member)
        {
            return _entityUpdateService.Update(member);
        }

        public virtual Member CreateMember(MemberInput memberInput)
        {
            return _entityCreationService.Create(memberInput);
        }

        public virtual dynamic GetTimestoreForMember(long memberId)
        {
            return _dynamicEntityRetrievalService.Get(TimeStoreUrl(memberId));
        }

        public virtual void WriteTimestoreForMember(long memberId, dynamic timestoreData)
        {
            _dynamicEntityCreationService.Create(TimeStoreUrl(memberId), timestoreData);
        }

        [Obsolete("Don't use this method, rather use the OTP system")]
        public virtual void ResetPasswordPin(long memberId)
        {
            _dynamicEntityCreationService.Create(string.Format("members/{0}/passwordPinReset", memberId), null);
        }

        protected virtual string TimeStoreUrl(long memberId)
        {
            return string.Format("members/{0}/timestore", memberId);
        }

    }
}
