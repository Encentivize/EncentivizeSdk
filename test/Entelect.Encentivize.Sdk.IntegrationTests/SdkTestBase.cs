using Entelect.Encentivize.Sdk.Achievements;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.MemberGrouping.Abilities;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupCreationTypes;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes;
using Entelect.Encentivize.Sdk.Members.Achievements;
using Entelect.Encentivize.Sdk.Members.Members;
using Entelect.Encentivize.Sdk.Members.Rewards;
using Entelect.Encentivize.Sdk.Otp.Configuration;
using Entelect.Encentivize.Sdk.Otp.Creation;
using Entelect.Encentivize.Sdk.Otp.Type;
using Entelect.Encentivize.Sdk.PointsTransactions;
using Entelect.Encentivize.Sdk.Program;
using Entelect.Encentivize.Sdk.SupportTickets;
using Entelect.Encentivize.Sdk.SupportTickets.Categories;
using Entelect.Encentivize.Sdk.SupportTickets.Types;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    public class SdkTestBase
    {
        private readonly EncentivizeRestClient _encentivizeRestClient;
        private readonly EncentivizeSettings _encentivizeSettings;
#if !DEBUG
            public const string Username = "alex66@doe66.co.zaQA";
            public const string Password = "tX3AyNWpwu8xG8tJ5EqujtNP";
            public const string BaseUrl = "https://qa.encentivize.co.za/api/v1/";
#else
        public const string Username = "encentivizeExceptions@entelect.co.za";
        public const string Password = "123456";
        public const string BaseUrl = "http://localhost:57441/api/v1/";
#endif
        public SdkTestBase()
        {

            _encentivizeSettings = new EncentivizeSettings(Username, Password, BaseUrl);
            _encentivizeRestClient = new EncentivizeRestClient(_encentivizeSettings);
        }

        public AchievementCategoriesClient AchievementCategoriesClient { get { return new AchievementCategoriesClient(_encentivizeRestClient); } }

        public AchievementsClient AchievementsClient { get { return new AchievementsClient(_encentivizeRestClient); } }

        public AbilitiesClient AbilitiesClient { get { return new AbilitiesClient(_encentivizeRestClient); } }

        public GroupCreationTypesClient GroupCreationTypesClient { get { return new GroupCreationTypesClient(_encentivizeRestClient); } }

        public GroupMembersClient GroupMembersClient { get { return new GroupMembersClient(_encentivizeRestClient); } }

        public GroupRolesClient GroupRolesClient { get { return new GroupRolesClient(_encentivizeRestClient); } }

        public GroupsClient GroupsClient { get { return new GroupsClient(_encentivizeRestClient); } }

        public GroupTypesClient GroupTypesClient { get { return new GroupTypesClient(_encentivizeRestClient); } }

        public MemberAchievementsClient MemberAchievementsClient { get { return new MemberAchievementsClient(_encentivizeRestClient); } }

        public MembersClient MembersClient { get { return new MembersClient(_encentivizeRestClient); } }

        public MemberRewardsClient MemberRewardsClient { get { return new MemberRewardsClient(_encentivizeRestClient); } }

        public OneTimePinConfigurationsClient OneTimePinConfigurationsClient { get { return new OneTimePinConfigurationsClient(_encentivizeRestClient); } }

        public OneTimePinsClient OneTimePinsClient { get { return new OneTimePinsClient(_encentivizeRestClient); } }

        public OneTimePinTypesClient OneTimePinTypesClient { get { return new OneTimePinTypesClient(_encentivizeRestClient); } }

        public PointsClient PointsClient { get { return new PointsClient(_encentivizeRestClient); } }

        public ProgramsClient ProgramsClient { get { return new ProgramsClient(_encentivizeRestClient); } }

        public SupportTicketCategoriesClient SupportTicketCategoriesClient { get { return new SupportTicketCategoriesClient(_encentivizeRestClient); } }

        public SupportTicketTypesClient SupportTicketTypesClient { get { return new SupportTicketTypesClient(_encentivizeRestClient); } }

        public SupportTicketsClient SupportTicketsClient { get { return new SupportTicketsClient(_encentivizeRestClient); } }
    }
}