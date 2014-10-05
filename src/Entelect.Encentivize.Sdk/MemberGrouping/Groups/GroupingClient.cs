using System.Collections.Generic;
using System.Linq;
using Entelect.Encentivize.Sdk.Clients;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using Entelect.Encentivize.Sdk.Members.Members;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Grouping
{
    public class GroupingClient : ClientBase, IGroupingClient
    {
        public GroupingClient(EncentivizeSettings settings) 
            : base(settings)
        {
        }

        public List<GroupOutput> GetGroups()
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<GroupOutput>>(request);
            return response.Data.Data;
        }

        public GroupOutput AddGroup(GroupOutput memberGroup)
        {
            var client = GetClient();
            var request = new RestRequest("Groups", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroup);
            var response = client.Execute<GroupOutput>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response);
            return response.Data;

        }

        public void UpdateGroup(GroupOutput memberGroup, int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("Groups/" + groupId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroup);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new UpdateFailedException(response);
        }

        public GroupOutput GetMemberGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("groups/{0}", groupId), Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<GroupOutput>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public void DeleteMemberGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            client.Execute<PagedResult<GroupOutput>>(request);
        }
        
    }
}