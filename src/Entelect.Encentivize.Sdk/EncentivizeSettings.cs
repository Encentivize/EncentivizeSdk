namespace Entelect.Encentivize.Sdk
{
    public class EncentivizeSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string BaseUrl { get; set; }

        public EncentivizeSettings(string username, string password, string baseUrl)
        {
            Username = username;
            Password = password;
            BaseUrl = baseUrl;
        }
    }
}