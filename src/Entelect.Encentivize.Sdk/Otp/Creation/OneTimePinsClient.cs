using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class OneTimePinsClient : IOneTimePinsClient
    {
        private readonly IEncentivizeRestClient _restClient;

        public OneTimePinsClient(IEncentivizeRestClient restClient)
        {
            _restClient = restClient;
            
        }

        public virtual void Create(CreateOneTimePinRequest createOneTimePinRequest)
        {
            var entityCreationService = new EntityCreationService<CreateOneTimePinRequest, object>(_restClient, new EntitySettings("One Time Pin", "One Time Pins", "Otp"));
            entityCreationService.CreateExpectNullResponse(createOneTimePinRequest);
        }

        public virtual void PasswordReset(OneTimePinPasswordResetInput oneTimePinPasswordResetInput)
        {
            var entityCreationService = new EntityCreationService<OneTimePinPasswordResetInput, object>(_restClient, new EntitySettings("One Time Pin Password Reset", "One Time Pin Password Resets", "OtpPasswordReset"));
            entityCreationService.CreateExpectNullResponse("otp/PasswordReset", oneTimePinPasswordResetInput);
        }
    }
}