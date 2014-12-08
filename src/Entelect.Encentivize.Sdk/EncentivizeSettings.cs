namespace Entelect.Encentivize.Sdk
{
    public class EncentivizeSettings
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string BearerToken { get; private set; }
        public string BaseUrl { get; set; }
        public AuthenticaionType AuthenticaionTypeToUse { get; private set; }

        public EncentivizeSettings(string username, string password, string baseUrl)
        {
            AuthenticaionTypeToUse = AuthenticaionType.Basic;
            Username = username;
            Password = password;
            BaseUrl = baseUrl;
        }

        public EncentivizeSettings(string bearerToken, string baseUrl)
        {
            AuthenticaionTypeToUse = AuthenticaionType.Neuron;
            BearerToken = bearerToken;
            BaseUrl = baseUrl;
        }

        public void SwitchToBasicAuth(string username, string password)
        {
            AuthenticaionTypeToUse = AuthenticaionType.Basic;
            Username = username;
            Password = password;
        }

        public void SwitchToNeuronAuth(string bearerToken)
        {
            AuthenticaionTypeToUse = AuthenticaionType.Neuron;
            BearerToken = bearerToken;
        }
    }
}