using RestSharp;

namespace Entelect.Encentivize.Sdk.Clients
{
    public abstract class ClientBase
    {
        protected ClientBase(EncentivizeSettings settings)
        {
            Settings = settings;
        }

        protected EncentivizeSettings Settings { get; set; }

        protected RestClient GetClient()
        {
            var client = new RestClient(Settings.BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(Settings.Username, Settings.Password);
            return client;
        }

        protected string GetErrorMessage(IRestResponse response)
        {
            return string.Format("Error response returned ({0} :{1}), Content: {2}", (int)response.StatusCode, response.StatusCode, response.Content);
        }
    }
}