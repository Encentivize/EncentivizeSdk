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
            var existingConfig = OneTimePinConfigurationClient.Get(1);
            if (existingConfig == null)
            {
                OneTimePinConfigurationClient.Create(new OneTimePinConfigurationInput
                {
                    IsActive = true,
                    MaxNumberOfRetries = 3,
                    OneTimePinTypeId = 1
                });
            }
            else if (!existingConfig.IsActive)
            {
                OneTimePinConfigurationClient.Update(new OneTimePinConfigurationInput {IsActive = true, MaxNumberOfRetries = 3, OneTimePinTypeId = 1});
            }
        }

        [Test]
        public void Create()
        {
            OtpClient.Create(new CreateOtpRequest
            {
                ChannelTypeId = 2,
                OtpTypeId = 1,
                UserIdentifier = Username
            });
        }

        [Test]
        public void PasswordReset()
        {
            OtpClient.PasswordReset(new OtpPasswordResetInput
            {
                OtpCode = 1, 
                Password = "NewPassword",
                UserIdentifier = Username
            });
        }
    }
}