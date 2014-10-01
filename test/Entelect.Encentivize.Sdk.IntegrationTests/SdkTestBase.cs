using Entelect.Encentivize.Sdk.Achievements;
using Entelect.Encentivize.Sdk.Grouping;
using Entelect.Encentivize.Sdk.Members;
using Entelect.Encentivize.Sdk.Points;
using Entelect.Encentivize.Sdk.Rewards;

namespace Entelect.Encentivize.Sdk.UnitTests
{
    public class SdkTestBase
    {
        public SdkTestBase()
        {
            const string username = "alex66@doe66.co.zaQA";
            const string password = "tX3AyNWpwu8xG8tJ5EqujtNP";
            const string baseUrl = "https://qa.encentivize.co.za/api/v1/";
            EncentivizeSettings = new EncentivizeSettings(username, password, baseUrl);
        }

        public EncentivizeSettings EncentivizeSettings { get; set; }

        public MemberClient MemberClient { get { return new MemberClient(EncentivizeSettings); } }

        public AchievementClient AchievementClient { get { return new AchievementClient(EncentivizeSettings); } }

        public GroupingClient GroupingClient { get { return new GroupingClient(EncentivizeSettings); } }

        public PointsClient PointsClient { get { return new PointsClient(EncentivizeSettings); } }

        public RewardClient RewardClient { get { return new RewardClient(EncentivizeSettings); } }
    }
}