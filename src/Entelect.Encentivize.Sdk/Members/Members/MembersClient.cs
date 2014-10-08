using System;
using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class MembersClient : IMembersClient
    {
        private readonly IEncentivizeRestClient _restClient;
        private readonly IEntityRetrievalService<Member> _entityRetrievalService;
        private readonly IEntityUpdateService<MemberInput, Member> _entityUpdateService;
        private readonly IEntityCreationService<MemberInput, Member> _entityCreationService;
        private readonly IEntityRetrievalService<dynamic> _dynamicEntityRetrievalService;

        public MembersClient(IEncentivizeRestClient restClient, 
            IEntityRetrievalService<Member> entityRetrievalService, 
            IEntityUpdateService<MemberInput, Member> entityUpdateService, 
            IEntityCreationService<MemberInput, Member> entityCreationService,
            IEntityRetrievalService<dynamic> dynamicEntityRetrievalService)
        {
            _restClient = restClient;
            _entityRetrievalService = entityRetrievalService;
            _entityUpdateService = entityUpdateService;
            _entityCreationService = entityCreationService;
            _dynamicEntityRetrievalService = dynamicEntityRetrievalService;
        }

        public MembersClient(IEncentivizeRestClient restClient)
        {
            _restClient = restClient;
            var memberSettings = new EntitySettings("Member", "Members", "members");
            var timeStoreEntitySettings = new EntitySettings("Timestore", "Timestore", "members/{memberId:long}/timestore/");
            _entityRetrievalService = new EntityRetrievalService<Member>(_restClient, memberSettings);
            _entityUpdateService = new EntityUpdateService<MemberInput, Member>(_restClient, memberSettings);
            _entityCreationService = new EntityCreationService<MemberInput, Member>(_restClient, memberSettings);
            _dynamicEntityRetrievalService = new EntityRetrievalService<dynamic>(_restClient, timeStoreEntitySettings);
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
            /*todo rk update this to use the new base once implemented*/
            return _entityUpdateService.Update(member.MemberId, member.ToInput());
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
            var request = new RestRequest(TimeStoreUrl(memberId))
            {
                Method = Method.POST, 
                RequestFormat = DataFormat.Json
            };
            request.AddBody(timestoreData);
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
        }

        [Obsolete("Don't use this method, rather use the OTP system")]
        public virtual void ResetPasswordPin(long memberId)
        {
            var request = new RestRequest(string.Format("members/{0}/passwordPinReset", memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new DataRetrievalFailedException(response);
            }
        }

        protected virtual string TimeStoreUrl(long memberId)
        {
            return string.Format("members/{0}/timestore", memberId);
        }

    }
}
