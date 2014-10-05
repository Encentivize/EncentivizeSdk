using Entelect.Encentivize.Sdk.Clients;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.PointsTransactions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Points
{
    public class PointsClient : ClientBase, IPointsClient
    {
        public PointsClient(EncentivizeSettings settings) : base(settings)
        {
        }

        public void AddAdhocPoints(long memberId, AdHocPointsInput adhocInput)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("members/{0}/AdHocPoints", memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(adhocInput);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response);

        }
    }
}