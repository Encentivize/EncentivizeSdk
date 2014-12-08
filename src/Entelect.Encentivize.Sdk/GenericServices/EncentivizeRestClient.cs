using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EncentivizeRestClient : RestClient, IEncentivizeRestClient
    {
        protected readonly EncentivizeSettings Settings;

        public EncentivizeRestClient(EncentivizeSettings settings)
            :base(settings.BaseUrl)
        {
            Settings = settings;
            if (Settings.AuthenticaionTypeToUse == AuthenticaionType.Basic)
            {
                Authenticator = new HttpBasicAuthenticator(Settings.Username, Settings.Password);
            }
            else if (Settings.AuthenticaionTypeToUse == AuthenticaionType.Neuron)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Settings.BearerToken);
            }
            AddHandler("application/json", new DynamicJsonDeserializer());
        }

        public virtual string GetErrorMessage(IRestResponse response)
        {
            return string.Format("Error response returned ({0} :{1}), Content: {2}", (int)response.StatusCode, response.StatusCode, response.Content);
        }
    }
}