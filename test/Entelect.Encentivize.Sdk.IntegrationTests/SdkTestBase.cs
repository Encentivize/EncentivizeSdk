using Entelect.Encentivize.Sdk.Achievements;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.MemberGrouping.Abilities;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes;
using Entelect.Encentivize.Sdk.MemberGrouping.Programs;
using Entelect.Encentivize.Sdk.Members;
using Entelect.Encentivize.Sdk.Members.Achievements;
using Entelect.Encentivize.Sdk.Members.Rewards;
using Entelect.Encentivize.Sdk.Otp.Configuration;
using Entelect.Encentivize.Sdk.Otp.Creation;
using Entelect.Encentivize.Sdk.Otp.Type;
using Entelect.Encentivize.Sdk.Points;
using Entelect.Encentivize.Sdk.SupportTickets.Categories;
using Entelect.Encentivize.Sdk.SupportTickets.Types;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class SdkTestBase
    {
        private readonly EncentivizeRestClient _encentivizeRestClient;
        private readonly EncentivizeSettings _encentivizeSettings;

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
            _encentivizeSettings = new EncentivizeSettings(username, password, baseUrl);
            _encentivizeRestClient = new EncentivizeRestClient(_encentivizeSettings);
        }

        public AchievementCategoryClient AchievementCategoryClient { get { return new AchievementCategoryClient(_encentivizeRestClient); } }

        public AchievementClient AchievementClient { get { return new AchievementClient(_encentivizeRestClient); } }

        public AbilitiesClient AbilitiesClient { get { return new AbilitiesClient(_encentivizeRestClient); } }

        public GroupCreationTypesClient GroupCreationTypesClient { get { return new GroupCreationTypesClient(_encentivizeRestClient); } }

        public GroupMembersClient GroupMembersClient { get { return new GroupMembersClient(_encentivizeRestClient); } }

        public GroupRolesClient GroupRolesClient { get { return new GroupRolesClient(_encentivizeRestClient); } }

        public GroupsClient GroupRolesGroupsClientClient { get { return new GroupsClient(_encentivizeRestClient); } }

        public GroupTypesClient GroupTypesClient { get { return new GroupTypesClient(_encentivizeRestClient); } }

        public MemberAchievementsClient MemberAchievementsClient { get { return new MemberAchievementsClient(_encentivizeRestClient); } }

        public MemberClient MemberClient { get { return new MemberClient(_encentivizeRestClient); } }

        public MemberRewardsClient MemberRewardsClient { get { return new MemberRewardsClient(_encentivizeRestClient); } }

        public OneTimePinConfigurationClient OneTimePinConfigurationClient { get { return new OneTimePinConfigurationClient(_encentivizeRestClient); } }

        public OtpClient OtpClient { get { return new OtpClient(_encentivizeRestClient); } }

        public OneTimePinTypesClient OneTimePinTypesClient { get { return new OneTimePinTypesClient(_encentivizeRestClient); } }

        public PointsClient PointsClient { get { return new PointsClient(_encentivizeRestClient); } }

        public ProgramsClient ProgramsClient { get { return new ProgramsClient(_encentivizeRestClient); } }

        public SupportTicketCategorysClient SupportTicketCategorysClient { get { return new SupportTicketCategorysClient(_encentivizeRestClient); } }

        public SupportTicketTypesClient SupportTicketTypesClient { get { return new SupportTicketTypesClient(_encentivizeRestClient); } }

        public SupportTicketsClient SupportTicketsClient { get { return new SupportTicketsClient(_encentivizeRestClient); } }
    }
}