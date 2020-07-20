using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MFL_Manager.Repositories.Interface;

namespace MFL_Manager.Repositories.Implementation
{
    public class RestApiRepository : IRestApiRepository
    {
        public virtual string GetRequest(Uri url, NameValueCollection headers = null)
        {
            using (var client = new WebClient())
            {
                if (headers != null)
                {
                    foreach (var key in headers.AllKeys)
                    {
                        client.Headers.Add(key, headers[key]);
                    }
                }

                string response = client.DownloadString(url);

                return response;
            }
        }

        public virtual string PostRequest(Uri url, HttpContent body, NameValueCollection headers = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers != null)
                {
                    foreach (var key in headers.AllKeys)
                    {
                        client.DefaultRequestHeaders.Add(key, headers[key]);
                    }
                }

                var responseMessage = Task.Run(async () => await client.PostAsync(url.PathAndQuery, body))
                    .GetAwaiter().GetResult();

                var responseJson = Task.Run(async () => await responseMessage.Content.ReadAsStringAsync())
                    .GetAwaiter().GetResult();

                return responseJson;
            }
        }
    }
}
