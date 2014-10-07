using RestSharp;
using RestSharp.Deserializers;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEncentivizeRestClient : IRestClient
    {
        /// <summary>
        /// Registers a content handler to process response content
        /// </summary>
        /// <param name="contentType">MIME content type of the response content</param><param name="deserializer">Deserializer to use to process content</param>
        void AddHandler(string contentType, IDeserializer deserializer);

        /// <summary>
        /// Remove a content handler for the specified MIME content type
        /// </summary>
        /// <param name="contentType">MIME content type to remove</param>
        void RemoveHandler(string contentType);
    }
}