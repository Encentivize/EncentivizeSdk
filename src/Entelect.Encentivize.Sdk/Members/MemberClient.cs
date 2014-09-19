using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Entelect.Encentivize.Sdk.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members
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

        public dynamic GetTimestoreForMember(long memberId)
        {
            var client = GetClient();
            var request = new RestRequest("members/{memberId}/timestore", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("memberId", string.Format("{0}", memberId));
            var response = client.Execute<dynamic>(request);
            return response.Content;
        }

        public void WriteTimestoreForMember(long memberId, dynamic timestore)
        {
            var baseUri = new Uri(Settings.BaseUrl);
            var postUri = new Uri(baseUri, "members/{memberId}/timestore");
            var response = Post(postUri.ToString(), Settings.Username, Settings.Password, timestore);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CreationFailedException(response.Content);
            }
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

        private HttpResponseMessage Post(string url, string username, string password, dynamic postData)
        {
            var uri = new Uri(url);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));

            var serializedData = JsonConvert.SerializeObject(postData);
            var task = client.PostAsync(uri, new StringContent(serializedData, Encoding.UTF8, "application/json"));
            var response = task.Result;
            return response;
        }
    }
}
