using Entelect.Encentivize.Sdk.Achievements;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.Grouping;
using Entelect.Encentivize.Sdk.Members;
using Entelect.Encentivize.Sdk.Points;
using Entelect.Encentivize.Sdk.Rewards;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class SdkTestBase
    {
        public SdkTestBase()
        {
#if !DEBUG
            const string username = "alex66@doe66.co.zaQA";
            const string password = "tX3AyNWpwu8xG8tJ5EqujtNP";
            const string baseUrl = "https://qa.encentivize.co.za/api/v1/";
#else
            const string username = "encentivizeExceptions@entelect.co.za";
            const string password = "123456";
            const string baseUrl = "http://localhost:57441/api/v1/";
#endif
            EncentivizeSettings = new EncentivizeSettings(username, password, baseUrl);
        }

        public EncentivizeSettings EncentivizeSettings { get; set; }

        public AchievementCategoryClient AchievementCategoryClient { get { return new AchievementCategoryClient(EncentivizeSettings); } }

        public MemberClient MemberClient { get { return new MemberClient(EncentivizeSettings); } }

        public MemberAchievementClient MemberAchievementClient { get { return new MemberAchievementClient(EncentivizeSettings); } }

        public GroupingClient GroupingClient { get { return new GroupingClient(EncentivizeSettings); } }

        public PointsClient PointsClient { get { return new PointsClient(EncentivizeSettings); } }

        public RewardClient RewardClient { get { return new RewardClient(EncentivizeSettings); } }
    }
}