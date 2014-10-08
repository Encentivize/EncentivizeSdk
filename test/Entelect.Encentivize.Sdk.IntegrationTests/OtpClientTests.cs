using Entelect.Encentivize.Sdk.Otp.Configuration;
using Entelect.Encentivize.Sdk.Otp.Creation;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class OtpClientTests : SdkTestBase
    {
        [TestFixtureSetUp]
        public void Initi()
        {
            var existingConfig = OneTimePinConfigurationsClient.Get(1);
            if (existingConfig == null)
            {
                OneTimePinConfigurationsClient.Create(new OneTimePinConfigurationInput
                {
                    IsActive = true,
                    MaxNumberOfRetries = 3,
                    OneTimePinTypeId = 1
                });
            }
            else if (!existingConfig.IsActive)
            {
                OneTimePinConfigurationsClient.Update(new OneTimePinConfigurationInput {IsActive = true, MaxNumberOfRetries = 3, OneTimePinTypeId = 1});
            }
        }

        [Test]
        public void Create()
        {
            OneTimePinsClient.Create(new CreateOneTimePinRequest
            {
                ChannelTypeId = 2,
                OtpTypeId = 1,
                UserIdentifier = Username
            });
        }

        [Test]
        [Ignore("This is difficult to test in an automated way since the otp is not actually returned but sent through the provided channel")]
        public void PasswordReset()
        {
            OneTimePinsClient.PasswordReset(new OneTimePinPasswordResetInput
            {
                OtpCode = 1, 
                Password = "NewPassword",
                UserIdentifier = Username
            });
        }
    }
}