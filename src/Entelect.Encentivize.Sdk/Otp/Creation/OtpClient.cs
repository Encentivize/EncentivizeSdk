﻿using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Otp.Creation
{
    public class OtpClient : IOtpClient
    {
        private readonly IRestClient _restClient;

        public OtpClient(IRestClient restClient)
        {
            _restClient = restClient;
            
        }

        public void Create(CreateOtpRequest createOtpRequest)
        {
            var entityCreationService = new EntityCreationService<CreateOtpRequest, object>(_restClient, new EntitySettings("Otp", "Otps", "Otp"));
            entityCreationService.CreateExpectNullResponse(createOtpRequest);
        }

        public void PasswordReset(OtpPasswordResetInput otpPasswordResetInput)
        {
            var entityCreationService = new EntityCreationService<OtpPasswordResetInput, object>(_restClient, new EntitySettings("Otp Password Reset", "Otp Password Resets", "OtpPasswordReset"));
            entityCreationService.CreateExpectNullResponse("otp/PasswordReset", otpPasswordResetInput);
        }
    }
}