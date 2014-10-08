using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class MembersClient : IMembersClient
    {
        private readonly IEncentivizeRestClient _restClient;
        private readonly EntityRetrievalService<MemberOutput> _entityRetrievalService;
        private readonly EntityUpdateService<MemberInput, MemberOutput> _entityUpdateService;
        private readonly EntityCreationService<MemberInput, MemberOutput> _entityCreationService;
        private readonly EntitySettings _timeStoreEntitySettings;

        public MembersClient(IEncentivizeRestClient restClient)
        {
            _restClient = restClient;
            var memberSettings = new EntitySettings("Member", "Members", "members");
            _timeStoreEntitySettings = new EntitySettings("Timestore", "Timestore", "members/{memberId:long}/timestore/");
            _entityRetrievalService = new EntityRetrievalService<MemberOutput>(_restClient, memberSettings);
            _entityUpdateService = new EntityUpdateService<MemberInput, MemberOutput>(_restClient, memberSettings);
            _entityCreationService = new EntityCreationService<MemberInput, MemberOutput>(_restClient, memberSettings);
        }

        public MemberOutput GetMe()
        {
            return _entityRetrievalService.Get("members/me");
        }

        public PagedResult<MemberOutput> Search(MemberSearchCriteria memberSearchCriteria)
        {
            return _entityRetrievalService.FindBySearchCriteria(memberSearchCriteria);
        }

        public MemberOutput Get(long memberId)
        {
            return _entityRetrievalService.GetById(memberId);
        }

        public MemberOutput UpdateMember(long memberId, MemberInput memberInput)
        {
            return _entityUpdateService.Update(memberId, memberInput);
        }

        public MemberOutput UpdateMember(MemberOutput memberOutput)
        {
            /*todo rk update this to use the new base once implemented*/
            return _entityUpdateService.Update(memberOutput.MemberId, memberOutput.ToInput());
        }

        public MemberOutput CreateMember(MemberInput memberInput)
        {
            return _entityCreationService.Create(memberInput);
        }

        public dynamic GetTimestoreForMember(long memberId)
        {
            var entityRetrievalService = new EntityRetrievalService<dynamic>(_restClient, _timeStoreEntitySettings);
            var data = entityRetrievalService.Get(TimeStoreUrl(memberId));
            return data;
        }

        public void WriteTimestoreForMember(long memberId, dynamic timestoreData)
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

        private string TimeStoreUrl(long memberId)
        {
            return string.Format("members/{0}/timestore", memberId);
        }

        public void ResetPasswordPin(long memberId)
        {
            var request = new RestRequest(string.Format("members/{0}/passwordPinReset", memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new DataRetrievalFailedException(response);
            }
        }

    }
}
