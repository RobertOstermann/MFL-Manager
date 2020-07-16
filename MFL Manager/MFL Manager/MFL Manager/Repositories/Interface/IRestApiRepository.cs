using System;
using System.Collections.Specialized;
using System.Net.Http;

namespace MFL_Manager.Repositories.Interface
{
    public interface IRestApiRepository
    {
        /// <summary>
        /// Perform a GET request and return the response body
        /// </summary>
        /// <param name="url">URL to request</param>
        /// <param name="headers">Optional headers to include in the request</param>
        /// <returns>Response body as a string</returns>
        string GetRequest(Uri url, NameValueCollection headers = null);

        /// <summary>
        /// Perform a POST request and return the response body
        /// </summary>
        /// <param name="url">URL to request</param>
        /// <param name="body">Request parameters</param>
        /// <param name="headers">Optional headers to include in the request</param>
        /// <returns>Response body as a string</returns>
        string PostRequest(Uri url, HttpContent body, NameValueCollection headers = null);
    }
}
