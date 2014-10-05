using Entelect.Encentivize.Sdk.Clients;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Members.Achievements
{
    public class MemberAchievementClient: ClientBase, IMemberAchievementClient
    {
        public MemberAchievementClient(EncentivizeSettings settings) 
            : base(settings)
        {
        }

        public AwardedAchievementOutput AddAchievementForMember(long memberId, AwardedAchievementInput memberAchievement)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("members/{0}/achievements", memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(memberAchievement);
            var response = client.Execute<AwardedAchievementOutput>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response);
            return response.Data;
        }
    }
}