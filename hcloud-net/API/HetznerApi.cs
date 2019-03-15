using hcloud_net.API.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace hcloud_net.API
{
    public enum HetznerApiStati
    {
        /// <summary>
        /// Non Hetzner Status, for internal use only
        /// </summary>
        All,

        Running,
        Success,
        Error
    }

    public class HetznerApiParameter
    {
        public HetznerApiStati Status = HetznerApiStati.All;

        public string Sort = null; // TODO figure a good way for this out
    }

    /// <summary>
    /// Main Junction. Will provide all functionality
    /// </summary>
    public class HetznerApi
    {
        /// <summary>
        /// The Api Token that will be used to talk to api
        /// </summary>
        readonly string ApiToken;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiToken">Your API Token</param>
        public HetznerApi(string apiToken)
        {
            ApiToken = apiToken;
        }

        /// <summary>
        /// Gets the action list known to api
        /// </summary>
        public async Task<ActionRequest> GetActionListAsync(HetznerApiParameter parameter = null)
        {
            return DeserializeStream<ActionRequest>(await SendRequestAsync(HetznerApiEndpoints.ActionEndpoint, parameter));
        }

        /// <summary>
        /// Gets a certain action from api
        /// </summary>
        public async Task<Actions> GetActionAsync(int actionId, HetznerApiParameter parameter = null)
        {
            return DeserializeStream<Actions>(await SendRequestAsync($"{HetznerApiEndpoints.ActionEndpoint}/{actionId}", parameter));
        }

        /// <summary>
        /// Sends a Request to API
        /// </summary>
        /// <param name="uri">the endpoint to contact</param>
        /// <returns>the response stream</returns>
        private async Task<Stream> SendRequestAsync(string uri, HetznerApiParameter parameter)
        {
            // TODO: Figure out if parameters are ignored atm (further ignored until confirmed)
            if(parameter != null)
            {
                bool addedParam = false;
                if(parameter.Status != HetznerApiStati.All)
                {
                    uri = $"{uri}?{parameter.Status}";
                    addedParam = true;
                }

                if(parameter.Sort != null)
                {
                        uri = $"{uri}{(addedParam ? ',' : '?')}{parameter.Status}";
                }
            }

            // Create Request
            var request = WebRequest.CreateHttp(uri);
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {ApiToken}");

            // Get Response
            var response = await request.GetResponseAsync();

            // Return stream
            return response.GetResponseStream();
        }

        /// <summary>
        /// Deserialize stream to generic object
        /// </summary>
        /// <typeparam name="T">The Class to Convert to</typeparam>
        /// <param name="stream">the data stream to convert</param>
        private T DeserializeStream<T>(Stream stream) where T : class
        {
            var sr = new DataContractJsonSerializer(typeof(T));
            return sr.ReadObject(stream) as T;
        }
    }
}
