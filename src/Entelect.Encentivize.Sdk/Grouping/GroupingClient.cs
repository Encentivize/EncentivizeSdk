using System;
using System.Collections.Generic;
using System.Linq;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.Members;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Grouping
{
    public class GroupingClient : ClientBase, IGroupingClient
    {
        public GroupingClient(EncentivizeSettings settings) 
            : base(settings)
        {
        }

        public List<MemberGroup> GetGroups()
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<MemberGroup>>(request);
            return response.Data.Data;
        }

        public MemberGroupDetails AddGroup(MemberGroup memberGroup)
        {
            var client = GetClient();
            var request = new RestRequest("Groups", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroup);
            var response = client.Execute<MemberGroupDetails>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);
            return response.Data;

        }

        public void UpdateGroup(MemberGroup memberGroup, int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("Groups/" + groupId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroup);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new UpdateFailedException(response.Content);
        }

        public MemberGroup GetMemberGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("groups/{0}", groupId), Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<MemberGroup>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public void DeleteMemberGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<MemberGroup>>(request);
        }

        public List<Member> GetMembersInGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.GET);
            request.AddParameter("externalReferenceCode", groupId);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Member>>(request);
            return response.Data.Data;
        }

        public void AddMemberToGroup(MemberGroupInput memberGroupInput, int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("Groups/" + groupId + "/Members", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroupInput);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);
        }

        public void RemoveMemberFromGroup(int groupId, int memberId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberRole(int groupId, int MemberId, MemberGroupRoles role)
        {
            throw new NotImplementedException();
        }
    }
}