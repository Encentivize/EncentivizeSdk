using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class OneTimePinsClient : IOneTimePinsClient
    {
        private readonly IEntityCreationService<CreateOneTimePinRequest> _createOneTimePinRequestService;
        private readonly IEntityCreationService<OneTimePinPasswordResetInput> _passwordResetCreationService;

        public OneTimePinsClient(IEntityCreationService<CreateOneTimePinRequest> createOneTimePinRequestService, 
            IEntityCreationService<OneTimePinPasswordResetInput> passwordResetCreationService)
        {
            _createOneTimePinRequestService = createOneTimePinRequestService;
            _passwordResetCreationService = passwordResetCreationService;
        }

        public OneTimePinsClient(IEncentivizeRestClient restClient)
        {
            var createOneTimePinRequestSettings = new EntitySettings("One Time Pin", "One Time Pins", "Otp");
            _createOneTimePinRequestService = new EntityCreationService<CreateOneTimePinRequest>(restClient, createOneTimePinRequestSettings);
            var passwordResetSettings = new EntitySettings("One Time Pin Password Reset", "One Time Pin Password Resets", "OtpPasswordReset");
            _passwordResetCreationService = new EntityCreationService<OneTimePinPasswordResetInput>(restClient, passwordResetSettings);
        }

        public virtual void Create(CreateOneTimePinRequest createOneTimePinRequest)
        {
            _createOneTimePinRequestService.Create(createOneTimePinRequest);
        }

        public virtual void PasswordReset(OneTimePinPasswordResetInput oneTimePinPasswordResetInput)
        {
            _passwordResetCreationService.Create("otp/PasswordReset", oneTimePinPasswordResetInput);
        }
    }
}