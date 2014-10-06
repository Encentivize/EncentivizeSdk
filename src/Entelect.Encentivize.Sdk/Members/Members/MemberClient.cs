using System.Linq;
using System.Net;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.Members.Members;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members
{
    public class MemberClient
    {
        private readonly IRestClient _restClient;
        private EntityRetrievalService<MemberOutput> _entityRetrievalService;

        public MemberClient(IRestClient restClient)
        {
            _restClient = restClient;
            _entityRetrievalService = new EntityRetrievalService<MemberOutput>(_restClient, new EntitySettings("Member", "Members", "members"));
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


        public void UpdateMember(MemberInput member, long encentivizeMemberId)
        {
            var request = new RestRequest("members/" + encentivizeMemberId, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(member);
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new UpdateFailedException(response);
            }
        }

        public void UpdateMember(MemberUpdate member, long encentivizeMemberId)
        {
            var request = new RestRequest("members/" + encentivizeMemberId, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(member);
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            { 
                throw new UpdateFailedException(response);
            }
        }

        public void AddMember(MemberInput member)
        {
            var request = new RestRequest("members", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(member);
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CreationFailedException(response); 
            }
        }

        public dynamic GetTimestoreForMember(long memberId)
        {
            var request = new RestRequest("members/{memberId}/timestore", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("memberId", string.Format("{0}", memberId));
            /*todo rk hack temporary fix for this method, change after refactoring*/
            var restClient = (RestClient) _restClient;
            restClient.AddHandler("application/json", new DynamicJsonDeserializer());
            var response = restClient.Execute<dynamic>(request).Data;
            return response;
        }

        public void WriteTimestoreForMember(long memberId, dynamic timestore)
        {
            var entityCreationService = new EntityCreationService<BaseInput, dynamic>(_restClient, new EntitySettings("Timestore", "Timestore", "members/{memberId:long}/timestore/"));
            entityCreationService.CreateExpectNullResponse(string.Format("members/{0}/timestore", memberId), timestore);
        }

        public void ResetPasswordPin(long memberId)
        {
            var request = new RestRequest(string.Format("members/{0}/passwordPinReset",memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new DataRetrievalFailedException(response); 
            }
        }

    }
}
