using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class OneTimePinsClient : IOneTimePinsClient
    {
        private readonly IEntityCreationService<CreateOneTimePinRequest, object> _createOneTimePinRequestService;
        private readonly IEntityCreationService<OneTimePinPasswordResetInput, object> _passwordResetCreationService;

        public OneTimePinsClient(IEntityCreationService<CreateOneTimePinRequest, object> createOneTimePinRequestService, 
            IEntityCreationService<OneTimePinPasswordResetInput, object> passwordResetCreationService)
        {
            _createOneTimePinRequestService = createOneTimePinRequestService;
            _passwordResetCreationService = passwordResetCreationService;
        }

        public OneTimePinsClient(IEncentivizeRestClient restClient)
        {
            var createOneTimePinRequestSettings = new EntitySettings("One Time Pin", "One Time Pins", "Otp");
            _createOneTimePinRequestService = new EntityCreationService<CreateOneTimePinRequest, object>(restClient, createOneTimePinRequestSettings);
            var passwordResetSettings = new EntitySettings("One Time Pin Password Reset", "One Time Pin Password Resets", "OtpPasswordReset");
            _passwordResetCreationService = new EntityCreationService<OneTimePinPasswordResetInput, object>(restClient, passwordResetSettings);
        }

        public virtual void Create(CreateOneTimePinRequest createOneTimePinRequest)
        {
            _createOneTimePinRequestService.CreateExpectNullResponse(createOneTimePinRequest);
        }

        public virtual void PasswordReset(OneTimePinPasswordResetInput oneTimePinPasswordResetInput)
        {
            _passwordResetCreationService.CreateExpectNullResponse("otp/PasswordReset", oneTimePinPasswordResetInput);
        }
    }
}