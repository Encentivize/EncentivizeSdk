using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.Members.Members;
using Newtonsoft.Json;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members
{
    public class MemberClient : IMemberClient
    {
        private readonly IRestClient _restClient;

        public MemberClient(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public MemberOutput GetMemberByExternalReference(string externalReference)
        {
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("externalReferenceCode", externalReference);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute<PagedResult<MemberOutput>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public MemberOutput GetMemberByMobileNumber(string mobileNumber)
        {
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("mobileNumber", mobileNumber);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute<PagedResult<MemberOutput>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public MemberOutput GetMemberByEmailAddress(string emailAddress)
        {
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("emailAddress", emailAddress);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute<PagedResult<MemberOutput>>(request);
            return response.Data != null ? response.Data.Data.FirstOrDefault() : null;
        }

        public PagedResult<MemberOutput> GetMembers(int? pageSize, int? pageNumber)
        {
            var request = new RestRequest("members", Method.GET);
            request.RequestFormat = DataFormat.Json;
            if (pageSize != null)
            {
                request.AddParameter("$PageSize", pageSize);
            }
            if (pageNumber != null)
            {
                request.AddParameter("$PageNo", pageNumber);
            }
            var response = _restClient.Execute<PagedResult<MemberOutput>>(request);
            return response.Data;
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

        public MemberOutput GetMe()
        {
            var request = new RestRequest("members/me", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute<MemberOutput>(request);
            return response.Data; 
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
