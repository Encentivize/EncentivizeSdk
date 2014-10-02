using RestSharp;

namespace Entelect.Encentivize.Sdk
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
    }
}