using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.Dto;


namespace Entelect.Encentivize.Sdk
{
    public class MemberClient : EncentivizeClientBase, IMemberClient
    {
        public MemberClient(EncentivizeSettings settings)
            :base(settings)
        {
        }
        public Member GetMemberByExternalReference(string externalReference)
        {
            var client = GetClient(); 
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("externalReferenceCode", externalReference);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Member>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public Member GetMemberByMobileNumber(string mobileNumber)
        {
            var client = GetClient();
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("mobileNumber", mobileNumber);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<PagedResult<Member>>(request);
 
            return response.Data.Data.FirstOrDefault();
        }

        public Member GetMemberByEmailAddress(string emailAddress)
        {
            var client = GetClient();
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("emailAddress", emailAddress);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Member>>(request);

            return response.Data != null ? response.Data.Data.FirstOrDefault() : null;
        }

        public PagedResult<Member> GetMembers(int? pageSize, int? pageNumber)
        {
            var client = GetClient();
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
            
            var response = client.Execute<PagedResult<Member>>(request);

            return response.Data;
        }

        public void UpdateMember(MemberInput member, long encentivizeMemberId)
        {
            var client = GetClient(); 
            var request = new RestRequest("members/" + encentivizeMemberId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(member);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new UpdateFailedException(response.Content); 
        }

        public void UpdateMember(MemberUpdate member, long encentivizeMemberId)
        {
            var client = GetClient();
            var request = new RestRequest("members/" + encentivizeMemberId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(member);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new UpdateFailedException(response.Content);
        }

        public void AddMember(MemberInput member)
        {
            var client = GetClient(); 
            var request = new RestRequest("members", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(member);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content); 
        }

        public Member GetMe()
        {
            var client = GetClient();
            var request = new RestRequest("members/me", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<Member>(request);
            return response.Data; 
        }

        public void ResetPasswordPin(long memberId)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("members/{0}/passwordPinReset",memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new DataRetrievalFailedException(response.Content); 
        }
    }
}
