﻿using Entelect.Encentivize.Sdk.Dto;
using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk
{
    public class PointsClient : EncentivizeClientBase, IPointsClient
    {
        public PointsClient(EncentivizeSettings settings) : base(settings)
        {
        }

        public void AddAdhocPoints(long memberId, MemberAdhocInput adhocInput)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("members/{0}/AdHocPoints", memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(adhocInput);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);

        }
    }
}