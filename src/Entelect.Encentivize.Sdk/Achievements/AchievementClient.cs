using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.Members;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public class AchievementClient: EncentivizeClientBase, IAchievementClient
    {
        public AchievementClient(EncentivizeSettings settings) 
            : base(settings)
        {
        }

        public MemberAchievement AddAchievementForMember(long memberId, AchievementInput achievement)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("members/{0}/achievements", memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(achievement);
            var response = client.Execute<MemberAchievement>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);
            return response.Data;
        }

        public MemberAchievement AddAchievementForMember(Member member, AchievementInput achievement)
        {
            return AddAchievementForMember(member.MemberId, achievement);
        }

        public Achievement GetById(long achievementId)
        {
            var client = GetClient();
            var request = new RestRequest("Achievements/" + achievementId, Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<Achievement>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);
            return response.Data;
        }
    }
}