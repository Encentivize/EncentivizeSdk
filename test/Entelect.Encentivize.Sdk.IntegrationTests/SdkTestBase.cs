using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.Members;
using Entelect.Encentivize.Sdk.Members.Achievements;

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
            EncentivizeRestClient = new EncentivizeRestClient(EncentivizeSettings);
        }

        public EncentivizeRestClient EncentivizeRestClient { get; set; }

        public EncentivizeSettings EncentivizeSettings { get; set; }

        public AchievementCategoryClient AchievementCategoryClient { get { return new AchievementCategoryClient(EncentivizeRestClient); } }

        public MemberClient MemberClient { get { return new MemberClient(EncentivizeSettings); } }

        public MemberAchievementsClient MemberAchievementClient { get { return new MemberAchievementsClient(EncentivizeRestClient); } }


    }
}