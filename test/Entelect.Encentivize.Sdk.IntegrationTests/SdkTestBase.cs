using Entelect.Encentivize.Sdk.Members;

namespace Entelect.Encentivize.Sdk.UnitTests
{
    public class SdkTestBase
    {
        public SdkTestBase()
        {
            const string username = "alex66@doe66.co.zaQA";
            const string password = "tX3AyNWpwu8xG8tJ5EqujtNP";
            const string baseUrl = "https://qa.encentivize.co.za/api/v1/";
            var encentivizeSettings = new EncentivizeSettings(username, password, baseUrl);
            MemberClient = new MemberClient(encentivizeSettings);
        }

        public MemberClient MemberClient { get; private set; }
    }
}